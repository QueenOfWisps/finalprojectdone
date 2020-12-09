using System.Linq;
using FinalProject.Models;

namespace FinalProject.Repos
{
    public interface IForum
    {
        IQueryable<ForumModel> Posts { get; }

        void AddPost(ForumModel Forum);

        ForumModel GetPostByTitle(string title);

    }
}
