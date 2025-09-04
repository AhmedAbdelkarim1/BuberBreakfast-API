using BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Sevices.Breakfasts
{
	public interface IBreakfastService
	{
		ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
		ErrorOr<Breakfast> GetBreakfast(Guid id);
		ErrorOr<UpsertedBreakfast> UpdateBreakfast(Breakfast breakfast);
		ErrorOr<Deleted> DeleteBreakfast(Guid id);
	}
}
