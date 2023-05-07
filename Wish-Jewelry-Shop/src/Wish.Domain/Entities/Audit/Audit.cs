using System.ComponentModel.DataAnnotations.Schema;
using Wish.Domain.Abstractions;
using Wish.Domain.Constants;
using Wish.Domain.Enums;

namespace Wish.Domain.Entities.Audit;

[Table(Tables.Audits)]
public class Audit : BaseEntity
{
	[Column(Columns.AuditMetaDataId)]
	public long AuditMetaDataId { get; set; }
	[ForeignKey(nameof(AuditMetaDataId))]
	public AuditMetaData AuditMetaData { get; set; } = new();
	[Column(Columns.CreatedAt)]
	public DateTime CreatedAt { get; set; }
	[Column(Columns.OldValues)]
	public string OldValues { get; set; } = string.Empty;
	[Column(Columns.NewValues)]
	public string NewValues { get; set; } = string.Empty;
	[Column(Columns.EntityState)]
	public int EntityState { get; set; }
	[Column(Columns.CreatedBy)]
	public long? CreatedBy { get; set; }
}
