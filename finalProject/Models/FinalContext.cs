using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class FinalContext : DbContext
    {
        //public FinalContext():base()
        //{

        //}
        public FinalContext(
            DbContextOptions<FinalContext> options) : base(options)
        {

        }



        public DbSet<ForumModel> Posts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuizModel> QuizUser { get; set; }//used to be quiz results.

        public DbSet<QuizTools> QuizResults { get; set; }

        

    }
}
