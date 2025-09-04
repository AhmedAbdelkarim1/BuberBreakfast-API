
namespace BuberBreakfast.Contracts.Breakfast
{
	public record BreakfastResponse(
		Guid Id,
		string Name,
		string Description,
		DateTime StartDateTime,
		DateTime EndDateTime,
		List<string> Savory,
		List<string> Sweet);
}
