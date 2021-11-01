using System;
using System.Collections.Generic;

namespace WebApplicationWithAuth.Data
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartsOn { get; set; }
        public List<SignUp> SignUps { get; set; }
    }
}
