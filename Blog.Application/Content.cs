namespace Blog.Application
{
    public class Content
    {
        public Content(IType type, string value)
        {
            Type = type;
            Value = value;
        }

        public IType Type { get; }
        public string Value { get; }
    }
}
