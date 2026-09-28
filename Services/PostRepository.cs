using System.Text.Json;
using MicroBlog.Models;

namespace MicroBlog.Services
{
	public class PostRepository
	{
		private readonly string _filePath;
		private readonly List<Post> _posts;

		public PostRepository(string contentRootPath)
		{
			string dataFolder = Path.Combine(contentRootPath, "data");

			Directory.CreateDirectory(dataFolder);

			_filePath = Path.Combine(dataFolder, "posts.json");

			_posts = LoadPosts();
		}

		public List<Post> GetAll()
		{
			return _posts
				.OrderByDescending(p => p.CreatedUtc)
				.ToList();
		}

		public Post? GetById(int id)
		{
			return _posts.FirstOrDefault(p => p.Id == id);
		}

		public void Add(Post post)
		{
			int nextId = _posts.Count == 0
				? 1
				: _posts.Max(p => p.Id) + 1;

			post.Id = nextId;
			post.CreatedUtc = DateTime.UtcNow;

			_posts.Add(post);

			SavePosts();
		}

		public bool Update(Post updatedPost)
		{
			Post? existingPost = GetById(updatedPost.Id);

			if (existingPost == null)
			{
				return false;
			}

			existingPost.Title = updatedPost.Title;
			existingPost.Body = updatedPost.Body;

			SavePosts();

			return true;
		}

		public bool Delete(int id)
		{
			Post? post = GetById(id);

			if (post == null)
			{
				return false;
			}

			_posts.Remove(post);

			SavePosts();

			return true;
		}

		private List<Post> LoadPosts()
		{
			if (!File.Exists(_filePath))
			{
				return new List<Post>();
			}

			string json = File.ReadAllText(_filePath);

			if (string.IsNullOrWhiteSpace(json))
			{
				return new List<Post>();
			}

			return JsonSerializer.Deserialize<List<Post>>(json)
				   ?? new List<Post>();
		}

		private void SavePosts()
		{
			string json = JsonSerializer.Serialize(
				_posts,
				new JsonSerializerOptions
				{
					WriteIndented = true
				});

			File.WriteAllText(_filePath, json);
		}
	}
}
