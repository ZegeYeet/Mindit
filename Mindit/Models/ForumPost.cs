

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mindit.Models
{
    public class ForumPost
    {

        [Key]
        public int PostId { get; set; }
        public string? mindyName { get; set; }
        public string? authorName { get; set; }


        [Required]
        public DateTime postDate { get; set; }
        [Required]
        public string postTitle { get; set; }
        [Required]
        public string postBody { get; set; }

        public int postLikes { get; set; }
        public int postDislikes { get; set; }

        public virtual ICollection<PostVotes>? postVotes { get; set; }
        public virtual ICollection<ForumReply>? forumReplies { get; set; }

        public ForumPost()
        {
            this.postDate = DateTime.UtcNow;
            this.postLikes = 0;
            this.postDislikes = 0;
            postVotes = new List<PostVotes>();
            forumReplies = new List<ForumReply>();
        }




    }
}
