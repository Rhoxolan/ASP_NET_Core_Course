using _2023._01._27_PW1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._01._27_PW1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public IActionResult Index(double leftTopFractionInput, double leftBottomFractionInput, double rightTopFractionInput, double rightBottomFractionInput)
		{
			double? res = default;
			foreach (var formElem in HttpContext.Request.Form)
			{
				if (formElem.Value == "addition")
				{
					res = AddFractions(leftTopFractionInput, leftBottomFractionInput, rightTopFractionInput, rightBottomFractionInput);
					break;
				}
				if (formElem.Value == "substraction")
				{
					res = SubtractFractions(leftTopFractionInput, leftBottomFractionInput, rightTopFractionInput, rightBottomFractionInput);
					break;
				}
				if (formElem.Value == "multiplication")
				{
					res = MultiplyFractions(leftTopFractionInput, leftBottomFractionInput, rightTopFractionInput, rightBottomFractionInput);
					break;
				}
				if (formElem.Value == "division")
				{
					res = DivideFractions(leftTopFractionInput, leftBottomFractionInput, rightTopFractionInput, rightBottomFractionInput);
					break;
				}
				if (formElem.Value == "power")
				{
					res = PowerOfFraction(leftTopFractionInput, leftBottomFractionInput, rightTopFractionInput, rightBottomFractionInput);
					break;
				}
			}
			return View(res);
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(null);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private double AddFractions(double leftTopFraction, double leftBottomFraction, double rightTopFraction, double rightBottomFraction)
			=> (leftTopFraction * rightBottomFraction + rightTopFraction * leftBottomFraction) / (leftBottomFraction * rightBottomFraction);

		private double SubtractFractions(double leftTopFraction, double leftBottomFraction, double rightTopFraction, double rightBottomFraction)
			=> (leftTopFraction * rightBottomFraction - rightTopFraction * leftBottomFraction) / (leftBottomFraction * rightBottomFraction);

		private double MultiplyFractions(double leftTopFraction, double leftBottomFraction, double rightTopFraction, double rightBottomFraction)
			=> (leftTopFraction * rightTopFraction) / (leftBottomFraction * rightBottomFraction);

		private double DivideFractions(double leftTopFraction, double leftBottomFraction, double rightTopFraction, double rightBottomFraction)
			=> (leftTopFraction * rightBottomFraction) / (rightTopFraction * leftBottomFraction);

		double PowerOfFraction(double leftTopFraction, double leftBottomFraction, double rightTopFraction, double rightBottomFraction)
			=> Math.Pow(Math.Pow(leftTopFraction / leftBottomFraction, rightTopFraction / rightBottomFraction), 1 / rightBottomFraction);

	}
}