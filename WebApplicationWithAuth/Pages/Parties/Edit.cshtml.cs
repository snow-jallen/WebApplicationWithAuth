using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.Parties
{
    [Authorize(Policy = AuthPolicies.IsAdmin)]
    public class EditModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public EditModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Party).State = EntityState.Modified;

            try
            {
                var claim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
                var currentUserName = claim.Value;
                Party.LastEditedBy = currentUserName;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(Party.Id))
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

        private bool PartyExists(int id)
        {
            return _context.Parties.Any(e => e.Id == id);
        }
    }
}
