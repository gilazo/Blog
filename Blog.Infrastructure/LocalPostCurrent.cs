using System.Collections.Generic;
using System.Linq;
using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPostCurrent : IQuery<Post>
    {
        private IQuery<IEnumerable<Post>> _posts;

        public LocalPostCurrent(IQuery<IEnumerable<Post>> posts)
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