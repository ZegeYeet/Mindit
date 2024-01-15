
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mindit.Models
{
    public class MinditCategoryModel
    {
        [Key]
        public string categoryName { get; set; }
        public string categoryCreator { get; set; }
        public string categoryDescription { get; set; }
        [Required]
        public bool categoryActive { get; set; }
        [Required]
        public DateTime creationDate { get; set; }

        public MinditCategoryModel()
        {
            this.creationDate = DateTime.UtcNow;
        }
    }
}
