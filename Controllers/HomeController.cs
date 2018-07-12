using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restauranter.Models;

namespace Restauranter.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;
        public HomeController(YourContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Reviewer> ReturnedValues = _context.reviews.ToList();//Where(r => r.Stars < 17).
            //List<Person> person is the model name  _context.reviewer reviewer is the table name matches
            ViewBag.allUsers = ReturnedValues;
            
            return View();
        }

        [HttpPost]
        [Route("CreateRecord")]
        public IActionResult CreateRecord(Reviewer NewReview)
        {

             if(ModelState.IsValid)
            {
            
                _context.Add(NewReview);
                _context.SaveChanges();
              
                 return RedirectToAction("ReviewPage");
            }
            else
            {
                return View("Index",NewReview);
            }
            // var today = DateTime.Today;
            // string date = today.ToString("MMMM d, yyyy");
            // System.Console.WriteLine(date);

            
        }

        public IActionResult ReviewPage()
        {
            List<Reviewer> AllValues = _context.reviews.ToList();
            
            //List<Person> person is the model name  _context.reviewer reviewer is the table name matches
            ViewBag.allReviews = AllValues.OrderByDescending(a => a.visit);
            System.Console.WriteLine("************************************The route hit***********************************************");

            return View("Reviews");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
