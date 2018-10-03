using System.IO;
using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPost : ISave<Post>
    {
        private string _path;
        private Post _post;

        public LocalPost(string path, Post post)
        {
            _path = path;
            _post = post;
        }

        public void Save()
        {
            File.WriteAllText(
                $@"{_path}/{_post.PostDateUtc.Year}/{_post.PostDateUtc.Month}/{_post.PostDateUtc.Day}/{_post.Title}.{_post.Content.Type.ShortHand}",
                _post.Content.Value);
        }
    }
}