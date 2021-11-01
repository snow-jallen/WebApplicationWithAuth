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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService authorizationService;

        public DetailsModel(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            this.authorizationService = authorizationService;           
        }

        public bool CanEdit { get; set; }

        public SignUp SignUp { get; set; }

        [BindProperty]
        public FoodAssignment NewFoodAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var authResult = await authorizationService.AuthorizeAsync(User, AuthPolicies.IsAdmin);
            CanEdit = authResult.Succeeded;

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

        public async Task<IActionResult> OnPost(int signupId)
        {
            if(ModelState.IsValid)
            {
                var signup = await _context.SignUps.Include(s => s.FoodAssignments).FirstOrDefaultAsync(s => s.Id == signupId);
                signup.FoodAssignments.Add(NewFoodAssignment);
                await _context.SaveChangesAsync();
                return RedirectToPage(signupId);
            }
            return Page();
        }
    }
}
