using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPostOptions
    {
        public LocalPostOptions(string path, IType type)
        {
            Path = path;
            Type = type;
        }

        public string Path { get; }
        public IType Type { get; }
    }
}