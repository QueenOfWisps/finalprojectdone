using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class QuizModel
    {
        public UserModel Q_user { get; set; }//name
        [Key]
        public string QuizID { get; set; }
        public int Score {get; set;}

        public QuizTools QuizToolInstance { get; set; }// this holds all values in the quiz tools model ie 
                                                       //parasites and seasons .

        /*
        public List<QuizModel> Seed(List<UserModel> users)
        //be sure to call in startup <3
        {
            //seeded data inside where its own model lives.
            var rec = new List<QuizModel>();

            //assign users to QuizModel randomly from users list
            rec.Add(new QuizModel() { Score = 10, Q_user = users.ElementAt(1) });// elemant at is a psudo array bracket with its index passed in.
            rec.Add(new QuizModel() { Score = 2, Q_user = users.ElementAt(3) });
            rec.Add(new QuizModel() { Score = 77 });
            rec.Add(new QuizModel() { Score = 99 });

            return rec;
        }
        */

    }

}
