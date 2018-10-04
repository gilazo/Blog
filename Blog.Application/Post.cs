using System;

namespace Blog.Application
{
    public class Post
    {
        private Post(DateTime postDateUtc, string title, Content content)
        {
            PostDateUtc = postDateUtc;
            Title = title;
            Content = content;
        }

        public DateTime PostDateUtc { get; }
        public string Title { get; }
        public Content Content { get; }

        public static Post New(string title, Content content) => new Post(DateTime.UtcNow, title, content);
        public static Post Past(DateTime postDateUtc, string title, Content content) => new Post(postDateUtc.ToUniversalTime(), title, content);
    }
}
