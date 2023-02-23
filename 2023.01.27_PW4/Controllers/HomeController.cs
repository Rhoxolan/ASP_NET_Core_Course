using _2023._01._27_PW4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

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
			//if(ModelState.IsValid)
			//{
				return View(car);
			//}
		}

		//Query example: /Home/CarFile?Model=Accord&Color=Red&Mark=Honda&Year=2003&EngineDisplacement=2.1
		public IActionResult CarFile(Car car)
		{
			return File(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(car)), "application/json", "car.json");
		}
	}
}