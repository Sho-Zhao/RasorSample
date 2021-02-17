using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RasorSample.Data;
using RasorSample.Model;

namespace RasorSample.Pages.BBS
{
    public class CreateModel : PageModel
    {
        private readonly RasorSample.Data.RasorSampleContext _context;

        public CreateModel(RasorSample.Data.RasorSampleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Writing Writing { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Writing.Add(Writing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
