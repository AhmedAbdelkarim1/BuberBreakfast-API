using BuberBreakfast.Models;

namespace BuberBreakfast.Sevices.Breakfasts
{
	public class BreakfastService : IBreakfastService
	{
		private readonly static Dictionary<Guid, Breakfast> _breakfasts = new();
		public void CreateBreakfast(Breakfast breakfast)
		{
			_breakfasts.Add(breakfast.Id, breakfast);
		}

		public Breakfast GetBreakfast(Guid id)
		{
			return _breakfasts[id];
		}

		public void UpdateBreakfast(Breakfast breakfast)
		{
			_breakfasts[breakfast.Id] = breakfast;
		}

		public void DeleteBreakfast(Guid id)
		{
			_breakfasts.Remove(id);
		}
	}
}
