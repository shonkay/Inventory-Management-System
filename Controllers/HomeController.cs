using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inventory_Management_System.Models;
using Inventory_Management_System.Interface;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Inventory_Management_System.ViewModels;

namespace Inventory_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _loginService;
        private readonly IInventoryService _inventory;

        public HomeController(ILogger<HomeController> logger, ILoginService loginService, IInventoryService inventory)
        {
            _logger = logger;
            _loginService = loginService;
            _inventory = inventory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(string UserName, string Password)
        {
            try
            {
                var user = _loginService.GetUser(UserName, Password);
                if (user.UserRole == "Admin")
                {
                    return Json(new { RespCode = 0, RespMessage = "Sucess" });
                }
               
            }
            catch (Exception ex)
            {
               return Json(new { RespCode = 2, RespMessage = ex.Message});
            }

            return Json(new { RespCode = 1, RespMessage = "Failure" });
        }

        public IActionResult AdminView()
        {
           var inventories = _inventory.GetAllInventories();
            return View(inventories);
        }

        public IActionResult EmployeeView()
        {
            return View();
        }

        public IActionResult AddNewInventory(InventoryViewModel model)
        {
            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
