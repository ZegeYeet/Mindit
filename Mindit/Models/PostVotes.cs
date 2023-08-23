using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mindit.Models
{
    public class PostVotes
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public ForumPost forumPost { get; set; }

        public string userName { get; set; }

        public string voteStyle { get; set; } //like or dislike

    }
}
