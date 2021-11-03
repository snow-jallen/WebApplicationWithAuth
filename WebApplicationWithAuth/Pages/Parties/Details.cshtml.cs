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
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationWithAuth.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplicationWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Party Party { get; set; }

        [BindProperty]
        public FoodAssignment NewFoodAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(string partyName)
        {
            if (partyName == null)
            {
                return NotFound();
            }

            Party = await _context.Parties.Include(p => p.SignUps).ThenInclude(s => s.FoodAssignments).FirstOrDefaultAsync(m => m.Name.ToLower() == partyName.ToLower());

            if (Party == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int signupId, string partyName)
        {
            if (ModelState.IsValid)
            {
                NewFoodAssignment.SignUpId = signupId;
                _context.FoodAssignments.Add(NewFoodAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { partyName = partyName });
        }
        
        public async Task<IActionResult> OnPostDeleteAssignmentAsync(int assignmentId, string partyName)
        {
            var foodAssignment = await _context.FoodAssignments.FindAsync(assignmentId);
            if (foodAssignment != null)
            {
                foodAssignment.IsDeleted = true;
                foodAssignment.LastEditedOn = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(new { partyName = partyName });
        }

        public async Task<IActionResult> OnPostAddNotesAsync(string notes, int assignmentId, string partyName)
        {
            var foodAssignment = await _context.FoodAssignments.FindAsync(assignmentId);
            if (foodAssignment != null)
            {
                foodAssignment.Notes = notes;
                foodAssignment.LastEditedOn = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(new { partyName = partyName });
        }
    }
}
