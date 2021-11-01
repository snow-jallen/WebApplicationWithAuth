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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService authorizationService;

        public IndexModel(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            this.authorizationService = authorizationService;
        }

        public IList<SignUp> SignUp { get;set; }
        public bool CanEdit { get; private set; }

        public async Task OnGetAsync()
        {
            SignUp = await _context.SignUps
                .Include(s => s.Party).ToListAsync();

            var authResult = await authorizationService.AuthorizeAsync(User, AuthPolicies.IsAdmin);
            CanEdit = authResult.Succeeded;
        }
    }
}
