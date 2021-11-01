namespace WebApplicationWithAuth.Data
{
    public class FoodAssignment
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Units { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int SignUpId { get; set; }
        public SignUp SignUp { get; set; }
    }
}
