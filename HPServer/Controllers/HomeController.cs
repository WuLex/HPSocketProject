using HPServer.Common;
using HPServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HPServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly HpSocketServer hpSocketServer;
        private readonly ILogger<HomeController> _logger;


        public HomeController(HpSocketServer hpSocketServer,ILogger<HomeController> logger)
        {
            this.hpSocketServer = hpSocketServer;
            _logger = logger;
        }
         
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartServer()
        {
            hpSocketServer.Start();
            return Ok("HP-Socket 服务启动了.");
        }

        [HttpPost]
        public IActionResult ProcessData(string data)
        {
            // 在这里处理从前端页面发送的数据
            return Ok($"接收前端发送的数据: {data}");
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