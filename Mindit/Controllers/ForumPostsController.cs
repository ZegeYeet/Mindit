using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mindit.Data;
using Mindit.Models;

namespace Mindit.Controllers
{
    public class ForumPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForumPosts
        public async Task<IActionResult> Index()
        {
            var forumPosts = from post in _context.ForumPost
                .Include(m => m.postVotes).OrderByDescending(i => i.postDate)
                             select post;

            return _context.ForumPost != null ?
                        View("Index", await forumPosts.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.WowClass'  is null.");
        }

        // GET: ForumPost/search
        public async Task<IActionResult> ShowSearchForm()
        {
            return _context.ForumPost != null ?
                        View() :
                        Problem("Entity set 'ApplicationDbContext.WowClass'  is null.");
        }

        // PoST: ForumPost/showSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.ForumPost != null ?
                        View("Index", await _context.ForumPost.Where(j => j.postBody.Contains(SearchPhrase)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.WowClass'  is null.");
        }

        // GET: ForumPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ForumPost == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost
                .Include(m => m.postVotes).FirstOrDefaultAsync(m => m.PostId == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        public async Task<IActionResult> NavMindySelection(string navClass)
        {
            var forumPosts = from post in _context.ForumPost select post;
            forumPosts = forumPosts.Where(j => j.mindyName.Contains(navClass))
                .Include(m => m.postVotes).OrderByDescending(i => i.postDate);

            return _context.ForumPost != null ?
                        View("Index", await forumPosts.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.WowClass'  is null.");
        }

        // GET: ForumPosts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mindyName,postTitle,postBody")] ForumPost forumPost)
        {
            forumPost.authorName = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Add(forumPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumPost);
        }

        // GET: ForumPosts/CreateReplyPage
        [Authorize]
        public IActionResult CreateForumReply()
        {
            return View();
        }

        // GET: ForumPosts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ForumPost == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }
            return View(forumPost);
        }

        // POST: ForumPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,className,authorName,classIcon,postDate,postTitle,postBody,postLikes,postDislikes")] ForumPost forumPost)
        {
            if (id != forumPost.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumPostExists(forumPost.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(forumPost);
        }

        // GET: ForumPosts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ForumPost == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // POST: ForumPosts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ForumPost == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ForumPost'  is null.");
            }
            var forumPost = await _context.ForumPost.FindAsync(id);
            if (forumPost != null)
            {
                _context.ForumPost.Remove(forumPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumPostExists(int id)
        {
          return (_context.ForumPost?.Any(e => e.PostId == id)).GetValueOrDefault();
        }

        // GET: likes - dislikes
        public async Task<IActionResult> GetVoteCount(int postId)
        {
            if (_context.ForumPost == null)
            {
                return Problem("Entity set is null.");
            }

            var forumPost = await _context.ForumPost
                .FirstOrDefaultAsync(m => m.PostId == postId);

            if (forumPost == null)
            {
                return Problem("no post found");
            }

            return Json(new {voteCount= forumPost.postLikes- forumPost.postDislikes });
        }

        // POST: change vote amount
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeVoteCount(int postId, string voteValue)
        {
            if (_context.ForumPost == null)
            {
                return Problem("Entity set is null.");
            }

            //get current post
            var forumPostToChange = await _context.ForumPost
                .Include(m => m.postVotes)
                .FirstOrDefaultAsync(m => m.PostId == postId);


            if (forumPostToChange == null)
            {
                return Problem("no post found");
            }


            //get current vote status for the post&user
            PostVotes pv;
            if (forumPostToChange.postVotes.Any(p => p.userName == User.Identity.Name))
            {
                Debug.WriteLine("found a vote for the post by the user");
                pv = forumPostToChange.postVotes.FirstOrDefault(p => p.userName == User.Identity.Name);
            }
            else
            {
                Debug.WriteLine("did not find a vote for the post by the user");
                pv = new PostVotes();
                pv.userName = User.Identity.Name;
                pv.voteStyle = voteValue;
                forumPostToChange.postVotes.Add(pv);

            }
            
            //update post and votes
            //remove current vote value
            if(pv.voteStyle == "upvoteFull")
            {
                forumPostToChange.postLikes = forumPostToChange.postLikes -1;
            }
            else if (pv.voteStyle == "downvoteFull")
            {
                forumPostToChange.postDislikes = forumPostToChange.postDislikes - 1;
            }
            else //post vote style is null or neutral
            {
                //do nothing
            }

            pv.voteStyle = "noVote";


            //add new value
            if (voteValue == "upvoteEmpty")
            {
                forumPostToChange.postLikes = forumPostToChange.postLikes + 1;
                pv.voteStyle = "upvoteFull";
            }
            else if (voteValue == "upvoteFull")
            {
                //already removed vote value and set vote style etc
            }
            else if (voteValue == "downvoteEmpty")
            {
                forumPostToChange.postDislikes = forumPostToChange.postDislikes + 1;
                pv.voteStyle = "downvoteFull";
            }
            else if (voteValue == "downvoteFull")
            {
                //already removed vote value and set vote style etc
            }


            _context.Entry(forumPostToChange).State = EntityState.Modified;
            _context.SaveChanges();




            

            return Json(new { voteLikes = forumPostToChange.postLikes, voteStyle = pv.voteStyle });
        }


    }
}
