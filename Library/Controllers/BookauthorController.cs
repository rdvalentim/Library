using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class BookauthorController : Controller
    {
        private readonly LibraryContext _context;

        public BookauthorController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Bookauthor
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Bookauthors.Include(b => b.Author).Include(b => b.Book);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Bookauthor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookauthor = await _context.Bookauthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookAuthorId == id);
            if (bookauthor == null)
            {
                return NotFound();
            }

            return View(bookauthor);
        }

        // GET: Bookauthor/Create
        public IActionResult Create()
        {
            var authors = _context.Authors
                .Select(a => new
                {
                    a.AuthorId,
                    FullName = a.FirstName + " " + a.LastName
                })
                .ToList();

            ViewData["AuthorId"] = new SelectList(authors, "AuthorId", "FullName");
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            return View();
        }

        // POST: Bookauthor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookAuthorId,BookId,AuthorId")] Bookauthor bookauthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookauthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "FirstName", bookauthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookauthor.BookId);
            return View(bookauthor);
        }

        // GET: Bookauthor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookauthor = await _context.Bookauthors.FindAsync(id);
            if (bookauthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "FirstName", bookauthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookauthor.BookId);
            return View(bookauthor);
        }

        // POST: Bookauthor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookAuthorId,BookId,AuthorId")] Bookauthor bookauthor)
        {
            if (id != bookauthor.BookAuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookauthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookauthorExists(bookauthor.BookAuthorId))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "FirstName", bookauthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookauthor.BookId);
            return View(bookauthor);
        }

        // GET: Bookauthor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookauthor = await _context.Bookauthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookAuthorId == id);
            if (bookauthor == null)
            {
                return NotFound();
            }

            return View(bookauthor);
        }

        // POST: Bookauthor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookauthor = await _context.Bookauthors.FindAsync(id);
            if (bookauthor != null)
            {
                _context.Bookauthors.Remove(bookauthor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookauthorExists(int id)
        {
            return _context.Bookauthors.Any(e => e.BookAuthorId == id);
        }
    }
}
