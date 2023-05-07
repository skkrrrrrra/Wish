using Wish.Domain.Entities;
using Wish.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using static Wish.Domain.Enums.Types;

namespace Wish.Application.Responses.Results
{
	public class InvalidResult<T> : Result<T>
	{
		private string _error;
		private List<IdentityError> _errorList;
		public InvalidResult(string error)
		{
			_error = error;
		}
		public InvalidResult(List<IdentityError> errors)
		{
			_errorList = errors;
		}
		public override ResultType ResultType => ResultType.Invalid;

		public override List<string> Errors => new List<string> { _error ?? "The input was invalid." };

		public override T Data => default(T);
	}
}
