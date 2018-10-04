using System.Linq;
using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPostCurrent : IQuery<Post>
    {
        private LocalPostMany _posts;

        public LocalPostCurrent(LocalPostMany posts)
        {
            _posts = posts;
        }

        public Post Query()
        {
            var posts = _posts.Query();
            if (!posts.Any())
                return default(Post);

            return posts.OrderBy(p => p.PostDateUtc).Last();
        }
    }
}