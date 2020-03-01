using System;
using System.Collections;
using System.Linq;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IPostService
    {
        Post Find(int postId);
        IEnumerable FindAll();
        bool Save(Post post);
        bool Edit(Post draft, int postId);
        bool Remove(int postId);
    }
    
    public class PostService : IPostService
    {
        private readonly BlogContext _context;

        public PostService(BlogContext context)
        {
            _context = context;
        }

        public Post Find(int postId)
        {
            try
            {
                return _context.Posts.Find(postId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable FindAll()
        {
            try
            {
                return _context.Posts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Enumerable.Empty<Post>();
            }
        }

        public bool Save(Post post)
        {
            try
            {
                _context.Add(post);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Edit(Post draft, int postId)
        {
            try
            {
                _context.Update(draft);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Remove(int postId)
        {
            try
            {
                _context.Remove(Find(postId));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}