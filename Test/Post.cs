using FinalProject.Controllers;
using FinalProject.Models;
using FinalProject.Repos;
using System;
using System.Linq;
using Xunit;

namespace Test
{
    public class PostTest
    {
        [Fact]
        public void ForumTest()
        {
            var fakerepo = new FakeForumRepository();
            var controller = new ForumController(fakerepo);
            var forum = new ForumModel()
            {
                //create values for empty repo.
                Title = "Plants are the greatest",
                F_user = new UserModel() { Name = "plantqueen" },
                Text = "So happy i took this"
            };

            //Act
            controller.Post(forum);

            forum = new ForumModel()
            {
                //create values for empty repo.
                Title = "Love this site",
                F_user = new UserModel() { Name = "sichi" },
                Text = "Wow i love this so much"
            };

            //Act
            controller.Post(forum);

            /*select * from Posts where title= "Love this site"*/
            //var query = from e in fakerepo.Posts
                      //  where e.Title == "Love this site"
                       // select e; this is how you access data using linq from a  database.

            var fetchPost = fakerepo.GetPostByTitle(forum.Title);

            //Ensure that the review was added to the repository
            Assert.True(forum.Title == fetchPost.Title);
        }
    }
}

