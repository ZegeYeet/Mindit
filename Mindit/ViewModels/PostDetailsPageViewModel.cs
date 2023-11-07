using Mindit.Models;

namespace Mindit.ViewModels
{
    public class PostDetailsPageViewModel
    {
        public ForumPost forumPost { get; set; }
        public ForumReply forumReply { get; set; }
        public string avatarString { get; set; }
    }
}
