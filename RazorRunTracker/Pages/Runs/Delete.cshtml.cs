using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRunTracker.Data;
using RazorRunTracker.Models;

namespace RazorRunTracker.Pages.Runs
{
    public class DeleteModel : PageModel
    {
        private readonly RazorRunTracker.Data.RazorRunTrackerContext _context;

        public DeleteModel(RazorRunTracker.Data.RazorRunTrackerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Run = await _context.Run.FindAsync(id);

            if (Run != null)
            {
                _context.Run.Remove(Run);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
