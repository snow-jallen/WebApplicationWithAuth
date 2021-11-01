using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.SignUps
{
    [Authorize(Policy = AuthPolicies.IsAdmin)]
    public class DeleteModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SignUp = await _context.SignUps.FindAsync(id);

            if (SignUp != null)
            {
                _context.SignUps.Remove(SignUp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
