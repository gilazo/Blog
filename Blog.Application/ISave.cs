namespace Blog.Application
{
    public interface ISave<in T>
    {
        void Save();
    }
}