using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
namespace FinalProject.Models
{
    public class ForumModel
    {
        //setting up a pimary key for story.
        [Key] // this makes double sure that the following property is the primary key ^o^
        public int PostID { get; set; }//using capital ID indicated primary key but do both love because its better for you ! 
        public UserModel F_user { get; set; }//name
        public string Title { get; set; }
        public QuizModel F_score { get; set; }
        public string Text { get; set; }



        
        //need to seed this?


        //public QuizModel QuizScore { get; set; }
       
        //setting up foriegn key from user in story. entity framework automatically sets up a relationship between these two tables 
        //when a username of type user is created. it just knows its from user. its magic.
        
    }
}
