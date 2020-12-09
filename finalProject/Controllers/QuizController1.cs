using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Vquiz()
        {
            QuizTools model = new QuizTools();
            return View(model);

        }

      

        [HttpPost]
        public IActionResult Vquiz(QuizTools model)
        {
            int scores = 0;
            //var quizModel = new QuizModel();//new instance of quiz model.
            if (model.Season == "a" || model.Season=="d")
            {
               // quizModel.QuizToolInstance = model;// accessing the data entered from quiztools instancw. 
                                                   // from the quiz model.
                                                   //change score. replace score with int in own table.
                scores += 5;
            }
            else
            {
                scores += 1;
            }

            
            if (model.Type == "a" || model.Type == "b")
            {
               // accessing the data entered from quiztools instancw. 
                // from the quiz model.
                scores += 5;// change score. replace score with int in own table.
            }
            else
            {
                scores += 1;
            }

            if (model.Moisture == "a" || model.Moisture == "d")
            {
                // accessing the data entered from quiztools instancw. 
                // from the quiz model.
                scores += 5;// change score. replace score with int in own table.
            }
            else
            {
                scores += 1;
            }

            if (model.Foilage== "b")
            {
                // accessing the data entered from quiztools instancw. 
                // from the quiz model.
                scores += 5;// change score. replace score with int in own table.
            }
            else if(model.Foilage=="b")
            {
                scores += 3;
            }
            else
            {
                scores += 1;
            }
            if (model.Fertilizer=="yes")
            {
                scores += 1;

            }
            else
            {
                scores += 5;
            }
            if(model.Sunlight=="a"|| model.Sunlight == "b")
            {
                scores += 5;
            }
            else
            {
                scores += 1;
            }

            if (model.Parasites == "a" || model.Parasites == "b" || model.Parasites == "c")
            {
                scores += 5;
            }
            else
            {
                scores += 500;
            }


            model.Score = scores;
         
           

            //var repo = new FinalContext();
            //repo.QuizResults.Add(quizModel);
            //repo.SaveChanges();

            return View(model);
        }

        public IActionResult QuizResult() 
        {
            return View();
        }
    }
}
