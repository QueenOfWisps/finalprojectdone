using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repos
{
    public class FakeForumRepository : IForum
    {
        List<ForumModel> postList = new List<ForumModel>();
        public IQueryable<ForumModel> Posts{ get{ return postList.AsQueryable<ForumModel>();} }

        public void AddPost(ForumModel forum)
        {
            // throw new NotImplementedException();
            forum.PostID = postList.Count;
            postList.Add(forum);
        }

        public ForumModel GetPostByTitle(string title)
        {
            var post = postList.Find(p => p.Title == title);
            return post;
        }
    }
}
