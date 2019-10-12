using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorRunTracker.Data;
using RazorRunTracker.Models;

namespace RazorRunTracker.Pages.Runs
{
    public class EditModel : PageModel
    {
        private readonly RazorRunTracker.Data.RazorRunTrackerContext _context;

        public EditModel(RazorRunTracker.Data.RazorRunTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Run Run { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Run = await _context.Run.FirstOrDefaultAsync(m => m.ID == id);

            if (Run == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Run).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RunExists(Run.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RunExists(int id)
        {
            return _context.Run.Any(e => e.ID == id);
        }
    }
}
