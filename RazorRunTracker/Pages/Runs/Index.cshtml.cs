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
    public class IndexModel : PageModel
    {
        private readonly RazorRunTracker.Data.RazorRunTrackerContext _context;

        public IndexModel(RazorRunTracker.Data.RazorRunTrackerContext context)
        {
            _context = context;
        }

        public IList<Run> Run { get;set; }

        public async Task OnGetAsync()
        {
            Run = await _context.Run.ToListAsync();
        }
    }
}
