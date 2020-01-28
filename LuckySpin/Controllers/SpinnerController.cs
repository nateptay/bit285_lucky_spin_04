using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        Random random = new Random(); //For use in the SpinIt Action
        /***
         * Entry Page Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View(); //Returns the empty Index.cshtml form
        }
        [HttpPost]
        public IActionResult Index(Player p1)
        { //TODO: Prepare Index action to receive a Player object instead of an integer
            //Make sure the game always works by defaulting to 7
            if (p1.LuckyNum < 1 || p1.LuckyNum > 9)
                p1.LuckyNum = 7;
            //TODO: Pass the Player object to SpinIt using RedirectToAction("SpinIt", object)
            return RedirectToAction("SpinIt", p1);
        }

        /***
         * Spin Action
         **/  
        [HttpGet]
        public IActionResult SpinIt(Player p1) //TODO: Prepare this method to receive a Player
        {
            //Load up a Spin object with data
            Spin spin = new Spin();
            ViewBag.Name = "Player";
            if (p1.Name != null)
                ViewBag.Name = p1.Name;
            spin.Luck = p1.LuckyNum; //TODO: Edit this to assign Player's lucky number to spin.Luck
            spin.A = random.Next(1, 10);
            spin.B = random.Next(1, 10);
            spin.C = random.Next(1, 10);

            // Test to see if a winner
            if (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck)
                spin.Display = "block";
            else
                spin.Display = "none";

            //Send the spin object to the View
            return View(spin);
        }
    }
}

