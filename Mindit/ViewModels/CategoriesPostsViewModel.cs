
using Mindit.Models;

namespace Mindit.ViewModels
{
    public class CategoriesPostsViewModel
    {
        public ForumPost forumPost { get; set; }
        public ICollection<MinditCategoryModel> categories { get; set; } 

    }
}
