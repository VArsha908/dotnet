using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeToPost.core;
using CodeToPost.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeToPost.Pages
{
    public class DetailModel : PageModel
    {
        private postData postData;

        [TempData]
        public string Message { get; set; }

        public Post Post { get; set; }

        public DetailModel(postData postData)
        {
            this.postData = postData;
        }

        public IActionResult OnGet(int ? postId)
        {
            if (postId.HasValue) 
            {
                Post = postData.GetById(postId.Value);
            }
            else
            {
                Post = new Post();
            }

            if (Post == null)
            {
                return RedirectToPage("./Posts/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Post.Id > 0)
            {
                postData.Update(Post);
            }
            else
            {
                postData.Add(Post);
            }
            postData.Commit();
            TempData["Message"] = "Post Saved!";
            return RedirectToPage("/Detail", new { postId = Post.Id });

        }
    }
    }
