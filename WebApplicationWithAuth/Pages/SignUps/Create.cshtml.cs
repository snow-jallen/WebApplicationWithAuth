using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationWithAuth.Data;

namespace WebApplicationWithAuth.Pages.SignUps
{
    //[Authorize(Policy = "IsSnowUser")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService authorizationService;

        public CreateModel(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            this.authorizationService = authorizationService;
        }

        public async Task<IActionResult> OnGet()
        {
            var result = await authorizationService.AuthorizeAsync(User, "IsSnowUser");
            ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public SignUp SignUp { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SignUps.Add(SignUp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
