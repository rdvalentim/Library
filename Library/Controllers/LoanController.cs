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
    public class LoanController : Controller
    {
        private readonly LibraryContext _context;

        public LoanController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Loan
        public async Task<IActionResult> Index()
        {
            var membersWithStatus = await _context
            .Loans
            .Include(l => l.Book)
            .Include(l => l.Member).ToListAsync();


            return View(membersWithStatus);
        }

        // GET: Loan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        private void FillViewData(Loan loan)
        {
            var members = _context.Members
                .Select(a => new
                {
                    a.MemberId,
                    FullName = a.FirstName + " " + a.LastName
                })
                .ToList();
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", loan.BookId);
            ViewData["MemberId"] = new SelectList(members, "MemberId", "FullName", loan.MemberId);
        }

        private void FillViewData()
        {
            var members = _context.Members
                .Select(a => new
                {
                    a.MemberId,
                    FullName = a.FirstName + " " + a.LastName
                })
                .ToList();
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            ViewData["MemberId"] = new SelectList(members, "MemberId", "FullName");
        }

        // GET: Loan/Create
        public IActionResult Create()
        {
            FillViewData();
            return View();
        }

        // POST: Loan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,BookId,MemberId,LoanDate,ReturnDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                if (!CanLoanBook(loan.BookId))
                {
                    ModelState.AddModelError("BookId", "Livro não disponível para empréstimo.");
                    FillViewData(loan);
                    return View(loan);
                }

                if (!CanMemberLoan(loan.MemberId))
                {
                    ModelState.AddModelError("MemberId", "Membro já possuí 3 emprestimos ou está inadimplente.");
                    FillViewData(loan);
                    return View(loan);
                }

                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            FillViewData(loan);
            return View(loan);
        }

        // GET: Loan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", loan.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", loan.MemberId);
            return View(loan);
        }

        // POST: Loan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,BookId,MemberId,LoanDate,ReturnDate")] Loan loan)
        {
            if (id != loan.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.LoanId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", loan.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", loan.MemberId);
            return View(loan);
        }

        // GET: Loan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }

        private bool CanLoanBook(int? bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return false;
            }

            var loans = _context.Loans.Where(l => l.BookId == bookId && l.ReturnDate == null).ToList();
            return loans.Count < book.NumberOfCopies;
        }

        private bool CanMemberLoan(int? memberId)
        {
            var member = _context.Members.Find(memberId);
            if (member == null)
            {
                return false;
            }

            var loans = _context.Loans.Where(l => l.MemberId == memberId && l.ReturnDate == null).ToList();

            if (loans.Count == 0)
            {
                return true;
            }

            return loans.Count < 3 && loans.Any(l => l.LoanDate.AddMonths(1) > DateOnly.FromDateTime(DateTime.Now));
        }
    }
}
