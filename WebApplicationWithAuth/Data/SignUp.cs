using System.Collections.Generic;
using System.ComponentModel;

namespace WebApplicationWithAuth.Data
{
    public class SignUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Party")]
        public int PartyId { get; set; }
        public Party Party { get; set; }
        public List<FoodAssignment> FoodAssignments { get; set; }
    }
}
