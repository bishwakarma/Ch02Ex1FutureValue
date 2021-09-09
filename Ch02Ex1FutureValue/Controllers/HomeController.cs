using Ch02Ex1FutureValue.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch02Ex1FutureValue.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        /// <summary>
        /// Action Controller method Index(), this runs in response to HTML GET or POST req.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Create 2 properties for Index() of the ViewBag property, these properties are auto available to controllers and view in this app. 
            //Setting the Name Property to the string value to the right.
            ViewBag.Name = "Mary";
            //Setting the FV (Future Value) property to the decimal value to the right. 
            ViewBag.FV = 9999.99;
            //Using View() method to return a ViewResult Object for the view accociated with the Index() action method.
            return View();
        }
        [HttpPost]
        
        //Action result for post http request passing in the model.
        public IActionResult Index(FutureValueModel model)
        {
            //Method that checks for Invalid Data using the ModelState Property.
            if (ModelState.IsValid)
            {
                //Using a ViewBag() method to calculate the FV and store in FV.
                ViewBag.FV = model.CalculateFutureValue();

            }
            else
            {
                ViewBag.FV = 0;
            }
            //Passed in model to the ViewResult so that the result can be displayed to the client. 
            return View(model);
        }
    }
}
