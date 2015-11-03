﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using M101DotNet.WebApp.Models;
using M101DotNet.WebApp.Models.Home;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace M101DotNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var blogContext = new BlogContext();

            // XXX WORK HERE
            // find the most recent 10 posts and order them
            // from newest to oldest

            /* Response */
            List<Post> recentPosts = await blogContext.Posts.Find(new BsonDocument())
                .Limit(10)
                .Sort(Builders<Post>.Sort.Descending("CreatedAtUtc"))
                .ToListAsync();
            /* ---- */

            var model = new IndexModel
            {
                RecentPosts = recentPosts
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NewPost()
        {
            return View(new NewPostModel());
        }

        [HttpPost]
        public async Task<ActionResult> NewPost(NewPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blogContext = new BlogContext();
            
            // XXX WORK HERE
            // Insert the post into the posts collection

            /* Response */
            Post post = new Post
            {
                Tags = model.Tags.Split(',').ToList(),
                Title = model.Title,
                Content = model.Content,
                Author = User.Identity.Name,
                CreatedAtUtc = DateTime.UtcNow,
                Comments = new List<Comment>()
            };

            await blogContext.Posts.InsertOneAsync(post);
            /* ---- */

            return RedirectToAction("Post", new { id = post.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Post(string id)
        {
            var blogContext = new BlogContext();

            // XXX WORK HERE
            // Find the post with the given identifier

            /* Response */
            Post post = await blogContext.Posts.Find(p => p.Id == ObjectId.Parse(id)).SingleAsync();
            /* ---- */

            if (post == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PostModel
            {
                Post = post
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Posts(string tag = null)
        {
            var blogContext = new BlogContext();

            // XXX WORK HERE
            // Find all the posts with the given tag if it exists.
            // Otherwise, return all the posts.
            // Each of these results should be in descending order.

            /* Response */
            FilterDefinitionBuilder<Post> builder = Builders<Post>.Filter;
            FilterDefinition<Post> filter = builder.Eq("Tags", tag);

            List<Post> posts = await blogContext.Posts.Find(filter).Limit(10).ToListAsync();
            /* ---- */

            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NewComment(NewCommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Post", new { id = model.PostId });
            }

            var blogContext = new BlogContext();

            // XXX WORK HERE
            // add a comment to the post identified by model.PostId.
            // you can get the author from "this.User.Identity.Name"

            /* Response */
            Comment comment = new Comment
            {
                CreatedAtUtc = DateTime.UtcNow,
                Author = User.Identity.Name,
                Content = model.Content
            };

            UpdateDefinition<Post> update = Builders<Post>.Update.AddToSet<Comment>("Comments", comment);
            await blogContext.Posts.FindOneAndUpdateAsync(p => p.Id == ObjectId.Parse(model.PostId), update);
            /* ------- */

            return RedirectToAction("Post", new { id = model.PostId });
        }
    }
}