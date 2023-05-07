using Wish.Domain.Entities;
using static Wish.Domain.Enums.Types;

namespace Wish.Application.Responses.Results
{
	public class UnexpectedResult<T> : Result<T>
	{
		public override ResultType ResultType => ResultType.Unexpected;

		public override List<string> Errors => new List<string> { "There was an unexpected problem" };

		public override T Data => default(T);
	}
}
