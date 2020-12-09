using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repos
{
    public class ForumRepository : IForum
    {
        private FinalContext context;

        public ForumRepository(FinalContext c)
        {
            context = c;

        }
        public IQueryable<ForumModel> Posts
        {
            get
            {
                return context.Posts.Include(post => post.F_user);
                //return an iqueryable
                //MIGHT NEED TO ADD MORE FOR QUIZ. DONT BE SHY.....PUT SOME MORE . NO.no its okay. PUT SOME MORE !!!
                //you can use .THENINCLUDE().
            }

        }
        public void AddPost(ForumModel forum)
        {
            //throw new NotImplementedException();
            context.Posts.Add(forum);
            context.SaveChanges();
        }

        public ForumModel GetPostByTitle(string title)
        {
           var post= context.Posts.Find(title);
            return post;

        }
    }
}
