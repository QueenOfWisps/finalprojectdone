using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using FinalProject.Repos;

namespace FinalProject.Controllers
{
    public class ForumController : Controller
      
    {
        
        IForum repo;

        
        //initialize
        public ForumController(IForum r)
        {
            repo = r;//object passed in and assigning object to context. 

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Post(ForumModel model)//pass in QuizModel as a quizmodel then instantiate it and add it. 
        {
            
            repo.AddPost(model);
            return Redirect("Forum");
          //  return View(model);
            //repo.AddPost(model)^


        }
        public IActionResult Forum(string name)
        {
            //might need to do an additional include statement.
            //var posts = context.Posts.Include(post => post.F_user).Include(quiz=>quiz.F_score).ToList<ForumModel>();
            //DONT BE SHY PUT SOME MORE. YOU MIGHT WANT TO DO .THENINCLUDE() INSTEAD OF THE ABOVE SIMILAR TO THE ONE IN FORUMREPOSITORY.CS
            // var posts = context.Posts.Include(post => post.F_user).ToList<ForumModel>(); this worked.
            //dont do the above
            //might need to include here.
            //return View(posts); //this worked 


             //var posts = repo.Posts.ToList<ForumModel>();//refactored
            var posts = (from r in repo.Posts where r.F_user.Name == name select r).ToList();
            return View(posts);

        }

       

        public IActionResult Rules()
        {
            return View();
        }
    }
}
