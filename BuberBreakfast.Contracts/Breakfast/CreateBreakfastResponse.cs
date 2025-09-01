using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Breakfast
{
	public record CreateBreakfastResponse
	{
		Guid Id;
		string Name;
		string Description;
		DateTime StartDateTime;
		DateTime EndDateTime;
		List<string> Savory;
		List<string> Sweet;

		public CreateBreakfastResponse
			(Guid id,
			string name
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

	}
}
