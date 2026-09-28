using MicroBlog.Models;
using MicroBlog.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PostRepository _repository;

        public List<Post> Posts { get; set; } = new List<Post>();

        public IndexModel(PostRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Posts = _repository.GetAll();
        }
    }
}
