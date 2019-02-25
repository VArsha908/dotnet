using CodeToPost.core;
using System.Collections.Generic;
using System.Text;



namespace CodeToPost.data
{
    public interface postData
    {
        IEnumerable<Post> GetPostsByName(string Name);
        Post GetById(int Id);
        Post Update(Post updatedPost);
        Post Add(Post newPost);
        Post Add1(Post newPost);
        Post Delete(int id);
        int Commit();
        Post Like(Post newPost);
    }
}
