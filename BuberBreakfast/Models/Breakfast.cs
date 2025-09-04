using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Models
{
	public class Breakfast
	{

		public Guid Id { get; }
		public string Name { get; }
		public string Description { get; }
		public DateTime StartDateTime { get; }
		public DateTime EndDateTime { get; }
		public List<string> Savory { get; }
		public List<string> Sweet { get; }


		private Breakfast(Guid id
			, string name
			, string description
			, DateTime startDateTime
			, DateTime endDateTime
			, List<string> savory
			, List<string> sweet)
		{
			Id = id;
			Name = name;
			Description = description;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			Savory = savory;
			Sweet = sweet;
		}

		public static ErrorOr<Breakfast> Create(
			string name,
			string description,
			DateTime startDateTime,
			DateTime endDateTime,
			List<string> savory,
			List<string> sweet,
			Guid? id = null)
		{
			List<Error> errors = new();

			if(name.Length < 3 || name.Length > 50)
			{
				errors.Add(Errors.Breakfast.InvalidName);
			}

			if(description.Length < 50 || description.Length > 150)
			{
				errors.Add(Errors.Breakfast.InvalidDescription);
			}

			if (errors.Any())
			{
				return errors;
			}

			return new Breakfast(
				id ?? Guid.NewGuid(),
				name,
				description,
				startDateTime,
				endDateTime,
				savory,
				sweet);
		}

		public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
		{
			return Create(
				request.Name,
				request.Description,
				request.StartDateTime,
				request.EndDateTime,
				request.Savory,
				request.Sweet);
		}
		public static ErrorOr<Breakfast> From(Guid id ,UpsertBreakfastRequest request)
		{
			return Create(
				request.Name,
				request.Description,
				request.StartDateTime,
				request.EndDateTime,
				request.Savory,
				request.Sweet,
				id);
		}

	}
}
