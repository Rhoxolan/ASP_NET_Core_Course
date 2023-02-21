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

		public IActionResult Index(double? leftTopFractionInput, double? leftBottomFractionInput, double? rightTopFractionInput, double? rightBottomFractionInput)
		{
			if(leftTopFractionInput is not null)
			{

			}
			return View();
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