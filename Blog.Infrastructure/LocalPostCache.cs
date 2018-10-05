using System;
using System.Collections.Generic;
using Blog.Application;

namespace Blog.Infrastructure
{
    public class LocalPostCache : IQuery<IEnumerable<Post>>
    {
        private IEnumerable<Post> _cache;
        private Func<IEnumerable<Post>> _getPosts;
        
        public LocalPostCache(Func<IEnumerable<Post>> getPosts)
        {
            _getPosts = getPosts;
        }

        public IEnumerable<Post> Query()
        {
            if (_cache == null)
                _cache = _getPosts() ?? new List<Post>();

            return _cache;
        }
    }
}