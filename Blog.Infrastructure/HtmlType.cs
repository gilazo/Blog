using Blog.Application;

namespace Blog.Infrastructure
{
    public class HtmlType : IType
    {
        public string LongHand => "HTML";
        public string ShortHand => "html";
    }
}