using GymWebApplication1.Data;
using GymWebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebApplication1.Controllers
{
    [Authorize]
    public class MembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [AllowAnonymous]
        // GET: Memberships
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var memberships = from m in _context.Memberships
                              select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                memberships = memberships.Where(m => m.MembershipName.Contains(searchString)
                                       || m.MembershipLastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    memberships = memberships.OrderByDescending(m => m.MembershipName);
                    break;
                case "Date":
                    memberships = memberships.OrderBy(m => m.MembershipLastName);
                    break;
                case "date_desc":
                    memberships = memberships.OrderByDescending(m => m.MembershipAge);
                    break;
                default:
                    memberships = memberships.OrderBy(m => m.MembershipName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Membership>.CreateAsync(memberships.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Memberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
       .Include(me => me.Bills)
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.MembershipId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: Memberships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipId,MembershipName,MembershipLastName,MembershipPhoneNumber,MembershipAge,MembershipEmail,PackageType")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membership);
        }

        // GET: Memberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipId,MembershipName,MembershipLastName,MembershipPhoneNumber,MembershipAge,MembershipEmail,PackageType")] Membership membership)
        {
            if (id != membership.MembershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipExists(membership.MembershipId))
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
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipExists(int id)
        {
            return _context.Memberships.Any(e => e.MembershipId == id);
        }
    }
}
