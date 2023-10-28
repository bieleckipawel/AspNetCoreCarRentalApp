namespace CarRentalApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int MfYear { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}
