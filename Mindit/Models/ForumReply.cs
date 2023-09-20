
using System.ComponentModel.DataAnnotations;

namespace Mindit.Models
{
    public class ForumReply
    {
        [Key]
        public int ReplyId { get; set; }
        public string? authorName { get; set; }


        [Required]
        public DateTime replyDate { get; set; }
        [Required]
        public string replyBody { get; set; }

        public int replyLikes { get; set; }
        public int replyDislikes { get; set; }

        //public virtual ICollection<ReplyVotes>? replyVotes { get; set; }

        public ForumReply()
        {
            this.replyDate = DateTime.UtcNow;
            this.replyLikes = 0;
            this.replyDislikes = 0;
            //postVotes = new List<PostVotes>();
        }
    }
}
