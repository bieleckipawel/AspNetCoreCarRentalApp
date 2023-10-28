namespace CarRentalApp.Models
{
    public class ViewModels
    {
        public class RentalViewModel
        {
            public Rental Rental { get; set; }
            public IList<Car> AvailableCars { get; set; }
            public IList<Customer> Customers { get; set; }
            public int SelectedCarId { get; set; }
            public int SelectedCustomerId { get; set; }
            public DateTime RentDate { get; set; }
            public DateTime ReturnDate { get; set; }
        }
    }
}
