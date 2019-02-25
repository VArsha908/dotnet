using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeToPost.core;
using CodeToPost.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CodeToPost.Pages.Posts
{
    public class ListModel : PageModel
    {
        public readonly IConfiguration config;
        public readonly postData postData;

        public string Message { get; set; }

        public IEnumerable<Post>Posts{get;set;}

        public ListModel(IConfiguration config , postData postData)
        {
            this.config = config;
            this.postData = postData;
        }

        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set;}

        public void OnGet(string SearchTerm)
        {
            Message = config["Message"];
            Posts = postData.GetPostsByName(SearchTerm);
        }


    }
}