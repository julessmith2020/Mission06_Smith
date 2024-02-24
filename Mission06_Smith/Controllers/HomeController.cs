using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Smith.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Smith.Controllers
{
    public class HomeController : Controller
    {
        // initialized the controller with the MovieFormContext
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

        // gets the form page with categories 
        public IActionResult FormPage() // allows categories to be diplayed
        {
            ViewBag.Categories = _context.Categories.ToList()
                .OrderBy(x => x.Category)
                .ToList(); 

            return View("FormPage", new MovieForm());
        }
        [HttpPost]

        // checks if the submitted form data is valid
        // if valid adds the movie record to the database and redirects to the confirmation view
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


        // Retrieves the movie record to edit from the database context
        // checks if the movie exists
        // retrieves categories from database and passes to view
        // renders the form page view w movie record for editing
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

        
        // updates the movie information with the new data provided
        // saves changes to the database
        // redirects to the movie list page after editing
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

        // view for more info on joel
        public IActionResult MoreJoel()
        {
            return View();
        }

        [HttpGet]
        
        // Retrieves the movie record to delete from the database context
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .SingleOrDefault(x => x.MovieId == id);


            return View(recordToDelete);
        }

        [HttpPost]

        // Removes the movie from database context
        // saves changes 
        // redirects to the movie list after deletion
        public IActionResult Delete(MovieForm movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Movielist");
        }
    }
}
