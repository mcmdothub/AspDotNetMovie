using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspDotNetMovie.Models;
using AspDotNetMovie.Services;
using AspDotNetMovie.Date;
using Omdb.API;

namespace AspDotNetMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly IMovieRepository _repository;
        private readonly IOmdbRepository _omdbRepository;

        public HomeController(
            ILogger<HomeController> logger, 
            IMailService mailService, 
            IMovieRepository repository,
            IOmdbRepository omdbRepository
            )
        {
            _logger = logger;
            _mailService = mailService;
            _repository = repository;
            _omdbRepository = omdbRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //MOVIE LIST


        // CONTACT
        // Controller for "Contact" page
        // this is for get information
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            // we use ViewBag.Title => to set the title of our page directly here inside the Controller
            //ViewBag.Title = "Contact Us";
            // we moved the title in Contact.cshtml
            //throw new InvalidOperationException("Bad things happen");
            return View();
        }

        // how we are goint to know which IActionResult Contact we are going to use?
        // using [HttpPost] is telling Mvc what kind of request is coming when i map these
        // this is for post
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("cristianmarin.se@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                // Show the errors
                // we dont need this because our view will show the error
            }

            // either case return the view
            return View();
        }


        // ABOUT
        // Controller for "About" page
        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }


        // SHOP
        public IActionResult Shop()
        {
            // this will go to the database and get all the products and return them "ToList()"
            // and we can even do some querying on them using the fluent syntax OrderBy(will take a small lambda to do the orderby category)
            // we can also do this directly with a LINQ query =>
            //var results = from p in _context.Products
            //              orderby p.Category
            //              select p;


            /*
             * this is fluent syntax
            var results = _context.Products
                .OrderBy(p => p.Category)
                .ToList();

            return View();
            */

            // and using LINQ in return View we call that ToList
            //return View(results.ToList());

            // conclution: we just ordering some data and then we passing into the View
            // step 2 make the view in Views/App/Shop.cshtml
            var results = _repository.GetAllMovies();

            return View(results);

        }


        // PRIVACY
        public async Task<IActionResult> Search(string SearchString)
        {
            var result = await _omdbRepository.Search(SearchString);

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
