using System.Diagnostics;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Interfaces;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Models;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IChatBotServices _chatBotServices;

        public HomeController(ILogger<HomeController> logger, IChatBotServices chaBotService)
        {
            _logger = logger;
            _chatBotServices = chaBotService;
        }

        public async Task<IActionResult> Index()
        { 
            
            string answer = await _chatBotServices.GetChatbotResponse("Dame un resumen de la pelicula titanic");
            return View(answer);

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
