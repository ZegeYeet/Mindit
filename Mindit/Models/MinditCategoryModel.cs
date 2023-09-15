
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

    }
}
