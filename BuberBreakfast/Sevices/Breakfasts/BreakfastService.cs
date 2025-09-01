using BuberBreakfast.Models;

namespace BuberBreakfast.Sevices.Breakfasts
{
	public class BreakfastService : IBreakfastService
	{
		private readonly static Dictionary<Guid, Breakfast> _breakfasts = new(); // static is to persist data across requests
		public void CreateBreakfast(Breakfast breakfast)
		{
			_breakfasts.Add(breakfast.Id, breakfast);
		}

		public Breakfast GetBreakfast(Guid id)
		{
			return _breakfasts[id];
		}
	}
}
