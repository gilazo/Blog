using System.Collections.Generic;

namespace Blog.Application
{
    public interface IQuery<out T>
    {
        T Query();
    }
}
