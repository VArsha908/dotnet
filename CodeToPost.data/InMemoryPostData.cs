using CodeToPost.core;
using System;
using System.Collections.Generic;
using System.Linq;



namespace CodeToPost.data
{
    public class InMemoryPostData : postData
    {
        readonly List<Post> posts;
        public InMemoryPostData()
        {
            posts = new List<Post>()
            {
                new Post { Id = 1,Name = "Varsha",Message = "hii" },
                new Post { Id = 2, Name = "Vivaan", Message = "hello"},
                new Post { Id = 3, Name = "Varsheel", Message = "hola"},
                new Post { Id = 4, Name = "Vanshul", Message = "hey"}
    };
        }


        public Post GetById(int id)
        {
            return posts.SingleOrDefault(p => p.Id == id);
        }

        public Post Add(Post newPost)
        {
            posts.Add(newPost);
            newPost.Id=posts.Max(p =>p.Id) + 1;
            return newPost;
        }

        public Post Add1(Post newPost)
        {
            posts.Add(newPost);
            newPost.Id=posts.Max(p => p.Id) + 1;
            return newPost;
        }

        public Post Update(Post updatedPost)
        {
            var post = posts.SingleOrDefault(p => p.Id == updatedPost.Id);
            if(post != null)
            {
                post.Name = updatedPost.Name;
                post.Message = updatedPost.Message;

            }
            return post;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Post> GetPostsByName(string name = null)
            {
            return from p in posts
                   where string.IsNullOrEmpty(name)|| p.Name.StartsWith(name)
                       orderby p.Id
                       select p;
            }

       

        //IEnumerable<Post> postData.GetPostsByName(string Name)
        //{
        //    throw new NotImplementedException();
        //}

        //Post postData.GetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //Post postData.Update(Post updatedPost)
        //{
        //    throw new NotImplementedException();
        //}

        //Post postData.Add(Post newPost)
        //{
        //    throw new NotImplementedException();
        //}

        //Post postData.Add1(Post newPost)
        //{
        //    throw new NotImplementedException();
        //}

        public Post Delete(int id)
        {
            var post = posts.FirstOrDefault(p =>p.Id ==id);
            if(post==null)
            {
                posts.Remove(post);
            }
            return post;
        }

        public Post Like(Post newPost)
        {
            throw new NotImplementedException();
        }

        //int postData.Commit()
        //{
        //    throw new NotImplementedException();
        //}



        //public Post Like(Post newPost)
        //{
        //    throw new NotImplementedException();
        //}
    }
    }
