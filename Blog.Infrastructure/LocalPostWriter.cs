using System.IO;
using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPostWriter : ISave<Post>
    {
        private LocalPostOptions _options;
        private Post _post;

        public LocalPostWriter(LocalPostOptions options, Post post)
        {
            _options = options;
            _post = post;
        }

        public void Save()
        {
            var path = Path.Combine(
                _options.Path, 
                $"{_post.PostDateUtc.Year}", 
                $"{_post.PostDateUtc.Month}", 
                $"{_post.PostDateUtc.Day}"
            );
            Directory.CreateDirectory(path);
            using (var streamWriter = new StreamWriter(Path.Combine(path, $"{_post.Title}.{_post.Content.Type.ShortHand}")))
            {
                streamWriter.Write(_post.Content.Value);
            }            
        }
    }
}
