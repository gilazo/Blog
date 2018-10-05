using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Infrastructure;
using Blog.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IQuery<IEnumerable<Post>> _posts;
        private LocalPostOptions _options;

        public PostsController(IQuery<IEnumerable<Post>> posts, LocalPostOptions options)
        {
            _posts = posts;
            _options = options;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return HandleRequest<IEnumerable<Post>>(() =>
            {
                return _posts.Query();
            });
        }

        [HttpGet]
        [Route("current")]
        public ActionResult GetCurrent()
        {
            return HandleRequest<Post>(() => 
            {
                return new LocalPostCurrent(
                    _posts
                )
                .Query();
            });
        }

        [HttpGet]
        [Route("{year}/{month}/{day}")]
        public ActionResult GetByDate([FromRoute] string year, string month, string day)
        {
            return HandleRequest<Post>(() =>
            {
                return _posts
                    .Query()
                    .First(p => p.PostDateUtc.Date == DateTime.Parse($"{year}-{month}-{day}").Date);
            });
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePost request)
        {
            return HandleRequest<object>(() =>
            {
                new LocalPostWriter(
                    _options,
                    Post.New(
                        request.Title, 
                        new Content(
                            _options.Type,
                            request.Content
                        )
                    )
                )
                .Save();

                return default(object);
            });           
        }

        private ActionResult HandleRequest<T>(Func<T> handler)
        {
            try
            {
                return Ok(Response<T>.Success(handler()));
            }
            catch(Exception ex)
            {
                return Ok(Response<T>.Error(ex.Message));
            }
        }
    }
}