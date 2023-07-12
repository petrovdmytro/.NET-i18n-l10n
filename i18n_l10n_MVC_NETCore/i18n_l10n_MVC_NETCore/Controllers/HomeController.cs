using i18n_l10n_MVC_NETCore.Converters;
using i18n_l10n_MVC_NETCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;

namespace i18n_l10n_MVC_NETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            string weightUnit_abbr = _stringLocalizer["WeightUnit_grammes_abbr"].Value;
            string lengthUnit_abbr = _stringLocalizer["LengthUnit_centimeter_abbr"].Value;
            string volumeUnit_abbr = _stringLocalizer["VolumeUnit_milliliter_abbr"].Value;

            double ballWeight = 450;//g
            double ballCircumference = 70;//cm
            double ballVolume = Math.Pow(ballCircumference, 3)/(6* Math.Pow(Math.PI,2));//ml

            var ri = new RegionInfo(System.Globalization.CultureInfo.CurrentCulture.LCID);
            if (!ri.IsMetric) {
                CustomImperialSystemConverter.TryConvertToPounds(ballWeight, CustomImperialSystemConverter.MetricSystemWeightUnit.Gramm, ref ballWeight);
                weightUnit_abbr = _stringLocalizer["WeightUnit_pounds_abbr"].Value;
                CustomImperialSystemConverter.TryConvertToInches(ballCircumference, CustomImperialSystemConverter.MetricSystemLengthUnit.Centimeter, ref ballCircumference);
                lengthUnit_abbr = _stringLocalizer["LengthUnit_inches_abbr"].Value;
                CustomImperialSystemConverter.TryConvertToFluidOunces(ballVolume, CustomImperialSystemConverter.MetricSystemVolumeUnit.Milliliter, ref ballVolume);
                volumeUnit_abbr = _stringLocalizer["VolumeUnit_fluidounces_abbr"].Value;
            }

            @ViewData["Weight"] = $"{_stringLocalizer["Weight"].Value}: " +
                $"{ballWeight:0.##} {weightUnit_abbr}";
            @ViewData["Circumference"] = $"{_stringLocalizer["Circumference"].Value}: " +
                $"{ballCircumference:0.##} {lengthUnit_abbr}";
            @ViewData["Volume"] = $"{_stringLocalizer["Volume"].Value}: " +
                $"{ballVolume:0.##} {volumeUnit_abbr}";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}