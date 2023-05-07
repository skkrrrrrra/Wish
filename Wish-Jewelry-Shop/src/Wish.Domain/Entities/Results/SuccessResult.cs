using Wish.Domain.Entities;
using Wish.Domain.Enums;
using static Wish.Domain.Enums.Types;

namespace Wish.Application.Responses.Results
{
	public class SuccessResult<T> : Result<T>
	{
		private readonly T _data;
		public SuccessResult(T data)
		{
			_data = data;
		}
		public override ResultType ResultType => ResultType.Ok;

		public override List<string> Errors => new List<string>();

		public override T Data => _data;
	}
}
