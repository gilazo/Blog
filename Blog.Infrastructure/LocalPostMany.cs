using System.Collections.Generic;
using System.IO;
using System.Linq;
using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPostMany : IQuery<IEnumerable<Post>>
    {
        private LocalPostOptions _options;

        public LocalPostMany(LocalPostOptions options)
        {
            _options = options;
        }

        public IEnumerable<Post> Query()
        {
            if (!Directory.Exists(_options.Path))
                return new Post[] {};
            
            return Directory
                .GetFiles(_options.Path, $"*.{_options.Type.Value}", SearchOption.AllDirectories)
                .Select(file => new FileInfo(file))
                .Select(info => Post.Past(info.CreationTimeUtc, Path.GetFileNameWithoutExtension(info.FullName), new Content(_options.Type, File.ReadAllText(info.FullName))))
                .OrderByDescending(c => c.PostDateUtc);
        }
    }
}
