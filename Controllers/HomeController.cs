using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("generation") == null)
        {
            HttpContext.Session.SetInt32("generation", 1);
        }
        else
        {
            int count = HttpContext.Session.GetInt32("generation").GetValueOrDefault();
            HttpContext.Session.SetInt32("generation", count + 1);
        }
        ViewBag.count = HttpContext.Session.GetInt32("generation");
        Random rand = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var newString = new char[14];
        for(int i = 0; i < newString.Length; i++){
            newString[i] = chars[rand.Next(0, 36)];
        }
        string newPassword = new String(newString);
        ViewBag.password = newPassword;
        return View();
    }
}
