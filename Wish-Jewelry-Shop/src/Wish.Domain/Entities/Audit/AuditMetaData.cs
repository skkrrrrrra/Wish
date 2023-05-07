using System.ComponentModel.DataAnnotations.Schema;
using Wish.Domain.Abstractions;
using Wish.Domain.Constants;

namespace Wish.Domain.Entities.Audit;

[Table(Tables.AuditMetaData)]
public class AuditMetaData : BaseEntity
{
	[Column(Columns.SchemaTable)]
	public string SchemaTable { get; set; } = string.Empty;
	[Column(Columns.TableName)]
	public string TableName { get; set; } = string.Empty;
	[Column(Columns.Schema)]
	public string Schema { get; set; } = string.Empty;
	[Column(Columns.HashPrimaryKey)]
	public string HashPrimaryKey { get; set; }  = string.Empty;
	[Column(Columns.ReadablePrimaryKey)]
	public string ReadablePrimaryKey { get; set; } = string.Empty;
	
	public ICollection<Audit> Audits { get; set; } = new List<Audit>();
}
