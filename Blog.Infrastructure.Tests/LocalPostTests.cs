using Blog.Application;
using Xunit;

namespace Blog.Infrastructure.Tests
{
    public class LocalPostTests
    {
        [Fact]
        public void Post_Save_Directory_Does_Not_Exist_Directory_Created()
        {
            new LocalPost(
                ".",
                new Post(
                    "test",
                    new Content(
                        new MarkdownType(),
                        "test"
                    ))
            ).Save();
        }
    }
}