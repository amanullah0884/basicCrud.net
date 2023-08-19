using BascCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BascCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            var data= Request.Form;
            var myId = data["myId"];
            HttpContext.Session.SetString("myId",myId);
            return RedirectToAction("ResultView");
        }

        public IActionResult ResultView()
        {
           var test= HttpContext.Session.GetString("myId");
            ViewBag.test = test;
            return View();
        }

        public IActionResult MovieIndex()
        {
            return View();

        }

        [HttpPost]
        [ActionName("MovieIndex")]
        public IActionResult MovieCreate(Movie movie)
        {
            var movieList= new List<Movie>();
            if (HttpContext.Session.GetString("Movie") != null)
            {
                movieList = JsonConvert.DeserializeObject<List<Movie>>(HttpContext.Session.GetString("Movie").ToString());
            }
            movieList.Add(movie);
            string serializedMovie = JsonConvert.SerializeObject(movieList);
            HttpContext.Session.SetString("Movie", serializedMovie);
            return View();

        }


        public IActionResult MovieList()
        {
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(HttpContext.Session.GetString("Movie").ToString());
            return View(movieList);

        }


    }
}