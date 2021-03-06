﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public IList<Writing> Writing { get;set; }  //For Index


        [BindProperty]
        public Writing WritingCreator { get; set; } //For Create

        public async Task OnGetAsync()  //For Index
        {
            Writing = await _context.Writing.ToListAsync();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()  //For Create
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            WritingCreator.ReleaseDate = DateTime.Now;  //投稿時の日付を自動記載
            _context.Writing.Add(WritingCreator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
