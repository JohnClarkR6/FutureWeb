using FutureWeb.Infrastructure;
using FutureWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureWeb.ViewModels
{
    public class PostsIndex
    {
        public PagedData<Post> Posts { get; set; }
    }

    public class PostsShow
    {
        public Post PostSingle { get; set; }
    }

    public class PostsTag
    {
        public Tag Tag { get; set; }
        public PagedData<Post> Posts { get; set; }
    }
}