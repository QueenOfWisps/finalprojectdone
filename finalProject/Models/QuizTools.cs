using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Controllers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class QuizTools
    {
        [Key]
        public int QuizToolId { get; set; }
        public string Season { get; set; }
        public string Type { get; set; }
        public string Moisture { get; set;  }
        public string Foilage { get; set; }
        public string Fertilizer { get; set; }
        public string Sunlight { get; set; }
        public string Parasites { get; set; }


        [NotMapped]
        public int Score { get; set; }


       /* public List<QuizTools> Seed()
            //be sure to call in startup <3
        {
            //seeded data inside where its own model lives.
            //instantiate new list of type model
            var rec = new List<QuizTools>();
            //add records to list.
            rec.Add(new QuizTools() { Parasites = "No"});
            rec.Add(new QuizTools() { Season = "Fall"});
            rec.Add(new QuizTools() { Season = "Winter"});
            rec.Add(new QuizTools() { Season = "Spring"});
            //return list
            return rec;
        }
       */

    }
}
