using Scalar.AspNetCore;

namespace BuberBreakfast
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			{
				builder.Services.AddControllers();
				builder.Services.AddOpenApi();
			}

			var app = builder.Build();
			{
				app.MapOpenApi();

				if (app.Environment.IsDevelopment())
				{
					app.MapScalarApiReference();
				}

				app.UseHttpsRedirection();
				app.UseAuthorization();
				app.MapControllers();
				app.Run();
			}

		}
	}
}
