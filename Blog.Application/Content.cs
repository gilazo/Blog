namespace Blog.Application
{
    public class Content
    {
        public Content(IType type, string value)
            : this(type.Value, value) {}

        public Content(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; }
        public string Value { get; }
    }
}
