using System;

namespace Blog.Application
{
    public class Post
    {
        public Post(string title, Content content)
            :this(DateTime.UtcNow, title, content) {}

        private Post(DateTime postDateUtc, string title, Content content)
        {
            PostDateUtc = postDateUtc;
            Title = title;
            Content = content;
        }

        public DateTime PostDateUtc { get; }
        public string Title { get; }
        public Content Content { get; }
    }
}
