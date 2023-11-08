using Mindit.Models;

namespace Mindit.ViewModels
{
    public class PostIndexViewModel
    {
        public List<ForumPost> indexForumPosts { get; set; } 
        public List<string> indexAvatarStrings { get; set; } = new List<string>();
    }
}
