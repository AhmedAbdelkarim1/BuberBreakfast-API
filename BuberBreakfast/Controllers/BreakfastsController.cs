using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class BreakfastsController : ControllerBase
	{
		[HttpPost]
		public IActionResult CreateBreakfast(CreateBreakfastRequest request)
		{
			return Ok(request);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetBreakfast(Guid id)
		{
			return Ok(id);
		}

		[HttpPut("{id:guid}")]
		public IActionResult UpdateBreakfast(Guid id, UpsertBreakfastRequest request)
		{
			return Ok(request);
		}

		[HttpDelete("{id:guid}")]
		public IActionResult UpdateBreakfast(Guid id)
		{
			return Ok(id);
		}




	}
}
