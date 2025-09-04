using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Sevices.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
	public class BreakfastsController : ApiController
	{
		private readonly IBreakfastService _breakfastService;

		public BreakfastsController(IBreakfastService breakfastService)
		{
			_breakfastService = breakfastService;
		}

		[HttpPost]
		public IActionResult CreateBreakfast(CreateBreakfastRequest request)
		{
			ErrorOr.ErrorOr<Breakfast> requestCreateBreakfast = Breakfast.From(request);

			if (requestCreateBreakfast.IsError)
			{
				return Problem(requestCreateBreakfast.Errors);
			}

			var breakfast = requestCreateBreakfast.Value;

			var createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

			return createBreakfastResult.Match(
				created => CreatedAtGetBreakfast(breakfast),
				errors => Problem(errors)
				);
		}

		

		[HttpGet("{id:guid}")]
		public IActionResult GetBreakfast(Guid id)
		{
			var getBreakfastResult = _breakfastService.GetBreakfast(id);

			return getBreakfastResult.Match(
				breakfast => Ok(MapToBreakfastResponse(breakfast)),
				errors => Problem(errors));
		}

		[HttpPut("{id:guid}")]
		public IActionResult UpdateBreakfast(Guid id, UpsertBreakfastRequest request)
		{
			var createBreakfastRequest = Breakfast.From(id, request);

			if (createBreakfastRequest.IsError)
			{
				return Problem(createBreakfastRequest.Errors);
			}

			var breakfast = createBreakfastRequest.Value;

			var updateBreakfastResult =  _breakfastService.UpdateBreakfast(breakfast);

			return updateBreakfastResult.Match(
				upserted => upserted.isNewlyCreated ? CreatedAtGetBreakfast(breakfast): NoContent(),
				errors => Problem(errors));
		}

		[HttpDelete("{id:guid}")]
		public IActionResult UpdateBreakfast(Guid id)
		{
			var deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

			return deleteBreakfastResult.Match(
				deleted => NoContent(),
				errors => Problem(errors));
		}

		private static BreakfastResponse MapToBreakfastResponse(Breakfast breakfast)
		{
			return new BreakfastResponse(
							Id: breakfast.Id,
							Name: breakfast.Name,
							Description: breakfast.Description,
							StartDateTime: breakfast.StartDateTime,
							EndDateTime: breakfast.EndDateTime,
							Savory: breakfast.Savory,
							Sweet: breakfast.Sweet);
		}

		private IActionResult CreatedAtGetBreakfast(Breakfast breakfast)
		{
			var response = MapToBreakfastResponse(breakfast); 
			return CreatedAtAction(
							nameof(GetBreakfast),
							new { id = breakfast.Id },
							response);
		}
	}
}
