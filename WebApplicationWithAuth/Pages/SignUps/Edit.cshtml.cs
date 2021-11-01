using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.SignUps
{
    public class EditModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public EditModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SignUp SignUp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SignUp = await _context.SignUps
                .Include(s => s.Party).FirstOrDefaultAsync(m => m.Id == id);

            if (SignUp == null)
            {
                return NotFound();
            }
           ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Id");
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

            _context.Attach(SignUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpExists(SignUp.Id))
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

        private bool SignUpExists(int id)
        {
            return _context.SignUps.Any(e => e.Id == id);
        }
    }
}
