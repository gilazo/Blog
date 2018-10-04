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
        private LocalPostOptions _options;

        public PostsController(LocalPostOptions options)
        {
            _options = options;
        }

        [HttpGet]
        public ActionResult GetLatest()
        {
            return HandleRequest<Post>(() => 
            {
                return new LocalPostCurrent(
                    new LocalPostMany(
                        _options
                    )
                )
                .Query();
            });
        }

        // [HttpGet]
        // [Route("{year}/{month}/{day}")]
        // public ActionResult GetByDate()
        // {

        // }

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