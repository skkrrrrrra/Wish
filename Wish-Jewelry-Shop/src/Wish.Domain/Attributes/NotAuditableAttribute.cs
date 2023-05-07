namespace Wish.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class NotAuditableAttribute : Attribute
{
	
}
