using static Wish.Domain.Enums.Types;

namespace Wish.Domain.Entities
{
	public abstract class Result<T>
	{
		public abstract ResultType ResultType { get; }
		public abstract List<string> Errors { get; }
		public abstract T Data { get; }
	}
}
