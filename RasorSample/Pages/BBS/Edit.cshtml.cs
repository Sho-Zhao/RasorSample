using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RasorSample.Data;
using RasorSample.Model;

namespace RasorSample.Pages.BBS
{
    public class EditModel : PageModel
    {
        private readonly RasorSample.Data.RasorSampleContext _context;

        public EditModel(RasorSample.Data.RasorSampleContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Writing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingExists(Writing.ID))
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

        private bool WritingExists(int id)
        {
            return _context.Writing.Any(e => e.ID == id);
        }
    }
}
