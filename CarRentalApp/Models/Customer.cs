namespace CarRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public bool HasRentedCar { get; set; }
    }
}
