using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.Parties
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Party Party { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Party = await _context.Parties.FirstOrDefaultAsync(m => m.Id == id);

            if (Party == null)
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

            Party = await _context.Parties.FindAsync(id);

            if (Party != null)
            {
                _context.Parties.Remove(Party);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
