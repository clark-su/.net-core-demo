using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.DTO;
using NetCore.Model;
using NetCoreDemo1.Models;

namespace NetCoreDemo1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //获取用户信息
            //IList<User> userList= UserDTO.GetAllUsers();
            //ViewData["UserList"] = userList;
            Task<string> str = GetMsg1();
            ViewBag.Str = str.Result;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        async void Get()
        {
            //Task.Run(()=> {
            //     GetMsg();
            // });
           string ss=await GetMsg1();
        }

        string GetMsg()
        {
            Thread.Sleep(5000);
            return "ok";
        }

        async Task<string> GetMsg1()
        {
            await Task.Run(() =>
             {
                //await Task.Delay(5000);
                Thread.Sleep(5000);
             });
            return "666";
        }
    }
}
