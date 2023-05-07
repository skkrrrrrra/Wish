using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Wish.Domain.Attributes;
using Wish.Domain.Entities.Audit;

namespace Wish.Persistence.Common;

internal static class InternalExtensions
    {
        internal static bool ShouldBeAudited(this EntityEntry entry)
        {
            return entry.State != EntityState.Detached && entry.State != EntityState.Unchanged &&
                   entry.Entity is not Audit && entry.Entity is not AuditMetaData &&
                   entry.IsAuditable();
        }

        private static bool IsAuditable(this EntityEntry entityEntry)
        {
            var attribute = Attribute.GetCustomAttribute(entityEntry.Entity.GetType(), typeof(AuditableAttribute));
            return attribute != null;
        }

        internal static bool IsAuditable(this PropertyEntry propertyEntry)
        {
            var entityType = propertyEntry.EntityEntry.Entity.GetType();
            var propertyInfo = entityType.GetProperty(propertyEntry.Metadata.Name);
            var disableAuditAttribute = propertyInfo != null
                                        && Attribute.IsDefined(propertyInfo, typeof(NotAuditableAttribute));

            return IsAuditable(propertyEntry.EntityEntry) && !disableAuditAttribute;
        }
    }

    public static class Extensions
    {
        public static string ToReadablePrimaryKey(this EntityEntry entry)
        {
            var primaryKey = entry.Metadata.FindPrimaryKey();
            return primaryKey != null
                ? string.Join(",",
                    primaryKey.Properties.ToDictionary(x => x.Name, x => x.PropertyInfo?.GetValue(entry.Entity))
                        .Select(x => x.Key + "=" + x.Value))
                : throw new Exception("Error when tried to create ReadablePrimaryKey");
        }

        public static string ToStringHash(this string readablePrimaryKey)
        {
            using SHA512 sha512 = SHA512.Create();
            var hashValue = sha512.ComputeHash(Encoding.Default.GetBytes(readablePrimaryKey));
            var reducedHashValue = new byte[16];
            for (var i = 0; i < 16; i++)
            {
                reducedHashValue[i] = hashValue[i * 4];
            }
            return new Guid(reducedHashValue).ToString();
        }
    }
