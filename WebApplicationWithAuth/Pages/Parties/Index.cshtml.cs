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
    public class IndexModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public IndexModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Party> Party { get;set; }

        public async Task OnGetAsync()
        {
            Party = await _context.Parties.ToListAsync();
        }
    }
}
