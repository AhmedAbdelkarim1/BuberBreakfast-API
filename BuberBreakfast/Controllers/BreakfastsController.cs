using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Sevices.Breakfasts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class BreakfastsController : ControllerBase
	{
		private readonly IBreakfastService _breakfastService;

		public BreakfastsController(IBreakfastService breakfastService)
		{
			_breakfastService = breakfastService;
		}

		[HttpPost]
		public IActionResult CreateBreakfast(CreateBreakfastRequest request)
		{
			var breakfast = new Breakfast(
				id: new Guid(),
				name: request.Name,
				description: request.Description,
				startDateTime: request.StartDateTime,
				endDateTime: request.EndDateTime,
				savory: request.Savory,
				sweet: request.Sweet);

			_breakfastService.CreateBreakfast(breakfast);

			var response = new BreakfastResponse(
				Id: breakfast.Id,
				Name: breakfast.Name,
				Description: breakfast.Description,
				StartDateTime: breakfast.StartDateTime,
				EndDateTime: breakfast.EndDateTime,
				Savory: breakfast.Savory,
				Sweet: breakfast.Sweet
				);
				
			return CreatedAtAction(
				nameof(GetBreakfast),
				new { id = breakfast.Id },
				response);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetBreakfast(Guid id)
		{
			var breakfast = _breakfastService.GetBreakfast(id);
			var response = new BreakfastResponse(
				Id: breakfast.Id,
				Name: breakfast.Name,
				Description: breakfast.Description,
				StartDateTime: breakfast.StartDateTime,
				EndDateTime: breakfast.EndDateTime,
				Savory: breakfast.Savory,
				Sweet: breakfast.Sweet
				);
			
			return Ok(response);
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
