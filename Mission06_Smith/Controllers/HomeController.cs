using Microsoft.AspNetCore.Mvc;
using Mission06_Smith.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Smith.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;

        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MoreJoel()
        {
            return View();
        }

        public IActionResult FormPage() 
        { 
            return View();
        }

        [HttpPost]

        public IActionResult FormPage(MovieForm response)
        {
            _context.MovieForms.Add(response); //add record to the database
            _context.SaveChanges();


            return View("Confirmation", response);
        }
    }
}
