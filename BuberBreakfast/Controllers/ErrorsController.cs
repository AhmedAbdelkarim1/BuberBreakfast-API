using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
	[ApiController]
	public class ErrorsController : ControllerBase
	{
		[HttpGet]
		[Route("/error")]
		public IActionResult Error() => Problem();
	}
}
