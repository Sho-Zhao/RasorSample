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
    public class IndexModel : PageModel
    {
        private readonly RasorSample.Data.RasorSampleContext _context;

        public IndexModel(RasorSample.Data.RasorSampleContext context)
        {
            _context = context;
        }

        public IList<Writing> Writing { get;set; }

        public async Task OnGetAsync()
        {
            Writing = await _context.Writing.ToListAsync();
        }
    }
}
