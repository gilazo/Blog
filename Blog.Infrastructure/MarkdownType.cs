using Blog.Application;

namespace Blog.Infrastructure
{
    public class MarkdownType : IType
    {
        public string LongHand => "Markdown";
        public string ShortHand => "md";
    }
}