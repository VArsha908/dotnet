using CodeToPost.Data;
using CodeToPost.core;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeToPost.data
{
    public class SqlPostData : postData
    {
        private readonly CodeToPostDbContext db;

        public SqlPostData(CodeToPostDbContext db)
        {
            this.db = db;
        }

        public Post Add(Post newPost)
        {
            db.Add(newPost);
            return newPost;
        }

        public Post Add1(Post newPost)
        {
            db.Add(newPost);
            return newPost;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Post Delete(int id)
        {
            var post = GetById(id);
            if(post!= null)
            {
                db.Posts.Remove(post);
            }
            return post;
        }

        public Post GetById(int id)
        {
            return db.Posts.Find(id);
        }

        public IEnumerable<Post>GetPostsByName(string name)
        {
            var query = from p in db.Posts
                        where p.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby p.Name
                        select p;
            return query;
        }

        public Post Like(Post newPost)
        {
            return db.ClickCounter();
        }

        public Post Update(Post updatedPost)
        {
            var entity = db.Posts.Attach(updatedPost);
            entity.State = EntityState.Modified;
            return updatedPost;
        }
    }
}
