using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult FormPage() // allows categories to be diplayed
        {
            ViewBag.Categories = _context.Categories.ToList()
                .OrderBy(x => x.Category)
                .ToList(); 

            return View("FormPage", new MovieForm());
        }
        [HttpPost]

        public IActionResult FormPage(MovieForm response) // only allows valid input
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList()
                    .OrderBy(x => x.Category)
                    .ToList();
                return View(response);
            }
        }

        public IActionResult Movielist()
        {
            //linq query
            //context then get the name of the table
            var movies = _context.Movies.Include(m => m.Category)
                            .OrderBy(x => x.MovieId).ToList();
            return View(movies); // i added "tolist' so might throw an error?
                                 //.Where(x => x.CreeperStalker == false)
                                 //.OrderBy(x => x.LastName).ToList();
        }

        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.FirstOrDefault(x => x.MovieId == id);
            if (recordToEdit == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categories.OrderBy(x => x.Category).ToList();
            return View("FormPage", recordToEdit);
        }
        [HttpPost]

        public IActionResult Edit(MovieForm updatedInfo)
        {

            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Movielist", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MoreJoel()
        {
            return View();
        }

        [HttpGet]
        

        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .SingleOrDefault(x => x.MovieId == id);


            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieForm movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Movielist");
        }
    }
}
