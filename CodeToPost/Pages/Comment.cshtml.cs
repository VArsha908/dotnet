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
    public class CommentModel : PageModel
    {


        //public void OnGet(int? postId)
        //{
        //    if (postId.HasValue)
        //    {
        //        Post = postData.GetById(postId.Value);
        //    }
        //    else
        //    {
        //        Post = new Post();
        //    }
        //    if (Post == null)
        //    {

        //    }
        //}


        private readonly postData postData;
        public object post1Data;

        [BindProperty]
        public Post Post { get; set; }
        public CommentModel()
        {
            this.postData = postData;
        }

        //public EditModel(postData postData)
        //{
        //    this.postData = postData;
        //}



        public IActionResult OnGet(int?postId)
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
                    return RedirectToPage("/Posts/NotFound");
                }
                return Page();
            }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    postData.Add(Post);
                }
                postData.Commit();
                TempData["Message"] = "Post Saved!";
                return RedirectToPage("/Comment", new { postId = Post.Id });

            }

        }
    }
