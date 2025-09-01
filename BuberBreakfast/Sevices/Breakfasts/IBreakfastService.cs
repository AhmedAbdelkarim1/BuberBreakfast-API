using BuberBreakfast.Models;

namespace BuberBreakfast.Sevices.Breakfasts
{
	public interface IBreakfastService
	{
		void CreateBreakfast(Breakfast breakfast);
		Breakfast GetBreakfast(Guid id);
	}
}
