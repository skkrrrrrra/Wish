using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wish.Domain.Entities;
using Wish.Domain.Entities.Audit;
using Wish.Persistence.Common;

namespace Wish.Persistence.Models;

public class AuditEntry
	{
        private string _readablePrimaryKey;
        public string ReadablePrimaryKey
        {
            get
            {
                if (string.IsNullOrEmpty(_readablePrimaryKey))
                    _readablePrimaryKey = Entry.ToReadablePrimaryKey();
                return _readablePrimaryKey;
            }
            set => _readablePrimaryKey = value;
        }
        public string HashReferenceId { get; set; }
		public EntityEntry Entry { get; }
		public string TableName { get; set; } = string.Empty;
		public string Schema { get; set; } = string.Empty;
		public string SchemaTable { get; set; } = string.Empty;
		public EntityState EntityState { get; set; }
		public long EntityId { get; set; }
		public long? UserId { get; set; }
		public Dictionary<string, object?> OldValues { get; } = new ();
		public Dictionary<string, object?> NewValues { get; } = new ();
		public ICollection<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

		public bool HasTemporaryProperties => TemporaryProperties.Any();

		public AuditEntry(EntityEntry entry, IAuditUserProvider? auditUserProvider)
        {
            Entry = entry;
            _readablePrimaryKey = Entry.ToReadablePrimaryKey();
            HashReferenceId = ReadablePrimaryKey.ToStringHash();
            TableName = entry.Metadata.GetTableName() ?? throw new Exception("Table name is null");
            Schema = entry.Metadata.GetSchema() ?? string.Empty;
            EntityState = entry.State;
            UserId = auditUserProvider?.GetUserId();

            foreach (var property in entry.Properties)
            {
                if (property.IsAuditable())
                {
                    if (property.IsTemporary)
                    {
                        TemporaryProperties.Add(property);
                        continue;
                    }

                    var propertyName = property.Metadata.Name;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                OldValues[propertyName] = property.OriginalValue;
                                NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
        }

        public void Update()
        {
            // Get the final value of the temporary properties
            foreach (var prop in TemporaryProperties)
            {
                NewValues[prop.Metadata.Name] = prop.CurrentValue;
            }

            if (TemporaryProperties.Any(x => x.Metadata.IsKey()))
            {
                ReadablePrimaryKey = Entry.ToReadablePrimaryKey();
                HashReferenceId = ReadablePrimaryKey.ToStringHash();
            }
        }

        public AuditMetaData ToAuditMetaDataEntity() =>
            new ()
            {
                Schema = Schema,
                TableName = TableName,
                SchemaTable = $"{(!string.IsNullOrEmpty(Schema) ? Schema + "." : "")}{TableName}",
                ReadablePrimaryKey = ReadablePrimaryKey,
                HashPrimaryKey = HashReferenceId
            };

        public Audit ToAuditEntity(AuditMetaData auditMetaData) =>
            new ()
            {
                OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
                EntityState = (int) EntityState,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = UserId,
                AuditMetaData = auditMetaData
            };

        public Audit ToAuditEntity() =>
            new ()
            {
                OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
                EntityState = (int) EntityState,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = UserId
            };
    }
