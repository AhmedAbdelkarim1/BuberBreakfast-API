using ErrorOr;

namespace BuberBreakfast.ServiceErrors
{
	public static class Errors
	{
		public static class Breakfast
		{
			public static Error NotFound => Error.NotFound(
				code: "Breakfast.NotFound",
				description: "Breakfast not found.");
			public static Error InvalidName => Error.Validation(
				code: "Breakfast.InvalidName",
				description: "Name must be between 3 and 50 char.");
			public static Error InvalidDescription => Error.Validation(
				code: "Breakfast.InvalidDescription",
				description: "Description must be between 3 and 50 char.");

		}
	}
}
