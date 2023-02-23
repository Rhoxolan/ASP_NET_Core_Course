using _2023._01._27_PW4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Environment;

namespace _2023._01._27_PW4.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		//Query example: /Home/CarInfo?Model=Accord&Color=Red&Mark=Honda&Year=2003&EngineDisplacement=2.1
		public IActionResult CarInfo(Car car)
		{
			ModelChecker(ModelState);
			return View(car);
		}

		//Query example: /Home/CarFile?Model=Accord&Color=Red&Mark=Honda&Year=2003&EngineDisplacement=2.1
		public IActionResult CarFile(Car car)
		{
			ModelChecker(ModelState);
			return File(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(car)), "application/json", "car.json");
		}

		private void ModelChecker(ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				Console.WriteLine($"Query validation errors count: {ModelState.ErrorCount}");
				StringBuilder stringBuilder = new();
				foreach (var modelValue in ModelState.Values)
				{
					if (modelValue.ValidationState != ModelValidationState.Valid)
					{
						foreach (var error in modelValue.Errors)
						{
							stringBuilder.AppendLine(error.ErrorMessage);
						}
					}
				}
				Console.WriteLine($"Errors: {NewLine}{stringBuilder}");
			}
		}
	}
}