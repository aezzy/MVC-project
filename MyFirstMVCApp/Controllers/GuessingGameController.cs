using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;



namespace MyFirstMVCApp.Controllers
{
    public class GuessingGameController : Controller
    {

       //create a variable 
        String _user = "Arwa";

        //create a random for every session
        Random _randNum = new Random();

        //create static variable for attempts made
        static int guess = 0;

       
        
        [HttpGet]
        public ActionResult Index()
        {

            
            //add string variable in your session
            HttpContext.Session.SetString("User", _user);
            ViewBag.Name = HttpContext.Session.GetString("User");

            //add random number in session
            int n = _randNum.Next(0, 101);
            HttpContext.Session.SetInt32("RandNum", n);
            ViewBag.Num = HttpContext.Session.GetString("RandNum");

            return View();



        }



        [HttpPost]
        public IActionResult GuessNumber()
        {
            
            string result;
            string result1;
            string result2;
            string result3;


          
            //loop the maximum tries as i which is not more than 5
            if(guess < 5)
            {

                //retrieve the number from input textbox
                int num1 = Convert.ToInt32(HttpContext.Request.Form["txtFirst"].ToString());
                guess++;
            
                //check if the number is higher than the session random number
                if (num1 < HttpContext.Session.GetInt32("RandNum"))
                {
                    //guess++;
                    result = "guesses:" + " " + guess;
                    result1 = "Go higher";
                    result2 = "the random number was:" + " " + HttpContext.Session.GetInt32("RandNum");

                    ViewBag.SumResult = result.ToString();
                    ViewBag.SumResult1 = result1.ToString();
                    ViewBag.SumResult2 = result2.ToString();

                    return View("index");




                }
               
                //check if the number is lower than the session random number
                else if (num1 > HttpContext.Session.GetInt32("RandNum"))
                {
                    result = "guesses:" + " " + guess;
                    result1 = "Go lower";
                    result2 = "the random number was:" + " " + HttpContext.Session.GetInt32("RandNum");

                    ViewBag.SumResult = result.ToString();
                    ViewBag.SumResult1 = result1.ToString();
                    ViewBag.SumResult2 = result2.ToString();

                    return View("index");


                }
               
                //check if the number is equal to session random number
                else if (num1 == HttpContext.Session.GetInt32("RandNum"))
                {
                   
                    result = "guesses:" + " " + guess;
                    result1 = "congratulations!";
                    result2 = "the random number was:" + " " + HttpContext.Session.GetInt32("RandNum");

                    ViewBag.SumResult = result.ToString();
                    ViewBag.SumResult1 = result1.ToString();
                    ViewBag.SumResult2 = result2.ToString();

                    return View("index");

                }
               


            }
           

            return View("Index");


        }

        










        ////ViewBag.Message("You have" + (allowedTries - numberOfTries), "tries left. Enter another number:");





    }
        }
    



        
  










  



     
