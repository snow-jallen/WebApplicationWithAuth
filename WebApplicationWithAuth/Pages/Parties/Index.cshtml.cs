using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.Parties
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;
        private readonly IAuthorizationService authorizationService;

        public IndexModel(WebApplicationWithAuth.Data.ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            this.authorizationService = authorizationService;
        }

        public IList<Party> Party { get;set; }
        public bool IsAdmin { get; private set; }

        public async Task OnGetAsync()
        {
            Party = await _context.Parties.ToListAsync();
            IsAdmin = (await authorizationService.AuthorizeAsync(User, AuthPolicies.IsAdmin)).Succeeded;
        }

        public async Task OnPostAsync()
        {
        }
    }
}
