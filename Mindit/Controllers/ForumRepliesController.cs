using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mindit.Data;
using Mindit.Models;
using Microsoft.AspNetCore.Authorization;

namespace Mindit.Controllers
{
    public class ForumRepliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumRepliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForumReplies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ForumReply.Include(f => f.forumPost);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ForumReplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ForumReply == null)
            {
                return NotFound();
            }

            var forumReply = await _context.ForumReply
                .Include(f => f.forumPost)
                .FirstOrDefaultAsync(m => m.ReplyId == id);
            if (forumReply == null)
            {
                return NotFound();
            }

            return View(forumReply);
        }

        // GET: ForumReplies/Create
        /*public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.ForumPost, "PostId", "postBody");
            return View();
        }*/

        // POST: ForumReplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,replyBody")] ForumReply forumReply)
        {
            //forumReply.PostId;

            //get current post
            var forumPostToChange = await _context.ForumPost
                .Include(m => m.postVotes)
                .FirstOrDefaultAsync(m => m.PostId == forumReply.PostId);


            if (forumPostToChange == null)
            {
                return Problem("no post found");
            }

            forumReply.authorName = User.Identity.Name;
            forumPostToChange.forumReplies.Add(forumReply);

            _context.Entry(forumPostToChange).State = EntityState.Modified;
            _context.SaveChanges();

            /*if (ModelState.IsValid)
            {
                _context.Add(forumReply);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ForumPosts", forumReply.PostId);
            }*/
            //ViewData["PostId"] = new SelectList(_context.ForumPost, "PostId", "postBody", forumReply.PostId);*/
            return RedirectToAction("Details", "ForumPosts", new {id = forumReply.PostId });
        }

        // GET: ForumReplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ForumReply == null)
            {
                return NotFound();
            }

            var forumReply = await _context.ForumReply.FindAsync(id);
            if (forumReply == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.ForumPost, "PostId", "postBody", forumReply.PostId);
            return View(forumReply);
        }

        // POST: ForumReplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReplyId,authorName,PostId,replyDate,replyBody,replyLikes,replyDislikes")] ForumReply forumReply)
        {
            if (id != forumReply.ReplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumReply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumReplyExists(forumReply.ReplyId))
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
            ViewData["PostId"] = new SelectList(_context.ForumPost, "PostId", "postBody", forumReply.PostId);
            return View(forumReply);
        }

        // GET: ForumReplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ForumReply == null)
            {
                return NotFound();
            }

            var forumReply = await _context.ForumReply
                .Include(f => f.forumPost)
                .FirstOrDefaultAsync(m => m.ReplyId == id);
            if (forumReply == null)
            {
                return NotFound();
            }

            return View(forumReply);
        }

        // POST: ForumReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ForumReply == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ForumReply'  is null.");
            }
            var forumReply = await _context.ForumReply.FindAsync(id);
            if (forumReply != null)
            {
                _context.ForumReply.Remove(forumReply);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumReplyExists(int id)
        {
          return (_context.ForumReply?.Any(e => e.ReplyId == id)).GetValueOrDefault();
        }
    }
}
