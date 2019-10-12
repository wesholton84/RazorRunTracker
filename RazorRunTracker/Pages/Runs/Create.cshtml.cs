using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorRunTracker.Data;
using RazorRunTracker.Models;

namespace RazorRunTracker.Pages.Runs
{
    public class CreateModel : PageModel
    {
        private readonly RazorRunTracker.Data.RazorRunTrackerContext _context;

        public CreateModel(RazorRunTracker.Data.RazorRunTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Run Run { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Run.Add(Run);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}