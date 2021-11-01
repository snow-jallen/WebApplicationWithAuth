using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.SignUps
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
