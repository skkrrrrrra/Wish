using System.ComponentModel.DataAnnotations;

namespace Wish.Domain.Enums
{
	public class Types
	{

		public enum ResultType
		{
			Ok,
			Invalid,
			Unauthorized,
			PartialOk,
			NotFound,
			PermissionDenied,
			Unexpected
		}
		public enum EventType
		{
			Holiday,
			EventOne,
			EventTwo
		}
        public enum MaterialType
        {
            Gold,
            Silver,
            Platinum
        }
    }
}
