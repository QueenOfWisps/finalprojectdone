using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        //[NotMapped]
        public string Name { get; set; }//name



        
        public List<UserModel> Seed()
        {
            //be sure to call in startup <3.


            //seeded data inside where its own table lives.
            //instantiate a new list of type usermodel
            var rec = new List<UserModel>();
            //add records to the list. 
            rec.Add(new UserModel() { Name = "Lindsey"});
            rec.Add(new UserModel() { Name = "Aria"});
            rec.Add(new UserModel() { Name = "Layla"});
            rec.Add(new UserModel() { Name = "Tony"});
            
            return rec;//return list.
        }
        
    }
}
