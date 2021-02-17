using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RasorSample.Data;
using RasorSample.Model;

namespace RasorSample.Pages.BBS
{
    public class DeleteModel : PageModel
    {
        private readonly RasorSample.Data.RasorSampleContext _context;

        public DeleteModel(RasorSample.Data.RasorSampleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Writing Writing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Writing = await _context.Writing.FirstOrDefaultAsync(m => m.ID == id);

            if (Writing == null)
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

            Writing = await _context.Writing.FindAsync(id);

            if (Writing != null)
            {
                _context.Writing.Remove(Writing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
