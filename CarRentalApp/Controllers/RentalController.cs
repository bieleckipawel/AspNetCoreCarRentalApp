using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class RentalController : Controller
    {
        private static IList<Car> cars = new List<Car>
        {
            new Car(){Id = 1, Make = "Toyota", Model = "Hilux", MfYear = 1988, Price = 20, Available = false},
            new Car(){Id = 2, Make = "BMW", Model = "M4 G82", MfYear = 2021, Price = 150, Available = true},
            new Car(){Id = 3,Make = "Mercedes", Model = "C63 AMG", MfYear = 2020, Price = 120, Available = true},
            new Car(){Id = 4,Make = "Audi", Model = "RS6", MfYear = 2021, Price = 200, Available = true},
            new Car(){Id = 5,Make = "Ford", Model = "Mustang", MfYear = 1969, Price = 100, Available = true},
            new Car(){Id = 6,Make = "Nissan", Model = "Skyline R34", MfYear = 1999, Price = 80, Available = true},
            new Car(){Id = 7,Make = "Mazda", Model = "RX7", MfYear = 1995, Price = 70, Available = true},
            new Car(){Id = 8,Make = "Subaru", Model = "WRX STI", MfYear = 2005, Price = 60, Available = true},
            new Car(){Id = 9,Make = "Mitsubishi", Model = "Lancer Evo", MfYear = 2008, Price = 50, Available = true},
            new Car(){Id = 10,Make = "Toyota", Model = "Supra", MfYear = 1995, Price = 90, Available = true},
            new Car(){Id = 11,Make = "Honda", Model = "Civic Type R", MfYear = 2018, Price = 80, Available = true},
            new Car(){Id = 12,Make = "Volkswagen", Model = "Golf GTI", MfYear = 2015, Price = 70, Available = true},
            new Car(){Id = 13,Make = "Porsche", Model = "911 GT3", MfYear = 2019, Price = 200, Available = true},
            new Car(){Id = 14,Make = "Lamborghini", Model = "Huracan", MfYear = 2020, Price = 300, Available = true},
            new Car(){Id = 15,Make = "Ferrari", Model = "F8 Tributo", MfYear = 2021, Price = 250, Available = true},
            new Car(){Id = 16, Make = "Aston Martin", Model = "DBS Superleggera", MfYear = 2020, Price = 300, Available = true},
            new Car(){Id = 17, Make = "McLaren", Model = "720S", MfYear = 2020, Price = 300, Available = true},
            new Car(){Id = 18, Make = "Bugatti", Model = "Chiron", MfYear = 2020, Price = 500, Available = true}
        };

        private static IList<Customer> customers = new List<Customer>
        {
            new Customer() { Id = 1, Name = "John Doe", PhoneNumber = "123456789" },
            new Customer() { Id = 2, Name = "Jane Doe", PhoneNumber = "987654321" },
            new Customer() { Id = 3, Name = "John Smith", PhoneNumber = "123123123" },
            new Customer() { Id = 4, Name = "Jane Smith", PhoneNumber = "321321321" },
            new Customer() { Id = 5, Name = "John Ijkl", PhoneNumber = "456456456" },
            new Customer() { Id = 6, Name = "Jane Ijkl", PhoneNumber = "654654654" },
            new Customer() { Id = 7, Name = "John Abcd", PhoneNumber = "789789789" },
            new Customer() { Id = 8, Name = "Jane Abcd", PhoneNumber = "987987987" },
            new Customer() { Id = 9, Name = "John Efgh", PhoneNumber = "147147147" },
            new Customer() { Id = 10, Name = "Jane Efgh", PhoneNumber = "741741741" }
        };

        private static IList<Rental> rentals = new List<Rental>
        {
            new Rental()
            {
                Id = 1, Customer = customers.FirstOrDefault(x=> x.Id ==1), Car = cars.FirstOrDefault(x=> x.Id ==1), RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1),
                TotalPrice = 20
            }
        };
        public IActionResult Cars()
        {
            
            return View(cars);
        }
        public ActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCar(Car car)
        {
            car.Id = cars.Count + 1;
            car.Available = true;
            cars.Add(car);
            return RedirectToAction("Cars");

        }
        public ActionResult DeleteCar(int id)
        {
            return View(cars.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCar(int id, Car car)
        {
            Car car1 = cars.FirstOrDefault(x => x.Id == id);
            cars.Remove(car1);

            return RedirectToAction("Cars");

        }

        public ActionResult DetailsCar(int id)
        {
            return View(cars.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult EditCar(int id)
        {
            return View(cars.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCar(int id, Car car)
        {
            Car car1 = cars.FirstOrDefault(x => x.Id == id);
            car1.Make = car.Make;
            car1.Model = car.Model;
            car1. MfYear = car.MfYear;
            car1.Price = car.Price;
            //car.MfYear = car1.MfYear;

            return RedirectToAction("Cars");
        }

        public IActionResult Customers()
        {
            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customer cat)
        {
            //meow
            cat.Id = customers.Count + 1;
            customers.Add(cat);
            return RedirectToAction("Customers");

        }

        public ActionResult EditCustomer(int id)
        {
            return View(customers.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(int id, Customer cat)
        {
            Customer cat1 = customers.FirstOrDefault(x => x.Id == id);
            cat1.Name = cat.Name;
            cat1.PhoneNumber = cat.PhoneNumber;
            return RedirectToAction("Customers");
        }

        public ActionResult DetailsCustomer(int id)
        {
            return View(customers.FirstOrDefault(x => x.Id == id));
        }

        /// todo: if customer have any rented car then dont delete
        public ActionResult DeleteCustomer(int id)
        {
            return View(customers.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id, Customer cust)
        {
            Customer cust1 = customers.FirstOrDefault(x => x.Id == id);
            customers.Remove(cust1);

            return RedirectToAction("Customers");

        }
        public IActionResult Rentals()
        {
            return View(rentals);
        }

        public ActionResult CreateRental(int id)
        {
            var viewModel = new ViewModels.RentalViewModel
            {
                AvailableCars = cars,
                SelectedCarId = id,
                Customers = customers
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRental(ViewModels.RentalViewModel rental)
        {
            Rental rental1 = new Rental();
            rental1.Id = rentals.Count + 1;
            rental1.Car = cars.FirstOrDefault(x => x.Id == rental.SelectedCarId);
            cars.FirstOrDefault(x => x.Id == rental.SelectedCarId).Available = false;
            rental1.Customer = customers.FirstOrDefault(x => x.Id == rental.SelectedCustomerId);
            rental1.RentDate = rental.RentDate;
            rental1.ReturnDate = rental.ReturnDate;
            rental1.TotalPrice = (rental.ReturnDate - rental.RentDate).Days * rental1.Car.Price;
            rentals.Add(rental1);
            return RedirectToAction("Rentals");

        }
        public ActionResult DeleteRental(int id)
        {
            return View(rentals.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRental(int id, Rental rental)
        {
            Rental rental1 = rentals.FirstOrDefault(x => x.Id == id);
            rentals.Remove(rental1);
            cars.FirstOrDefault(x => x.Id == rental1.Car.Id).Available = true;
            return RedirectToAction("Rentals");

        }
        public ActionResult DetailsRental(int id)
        {
            return View(rentals.FirstOrDefault(x => x.Id == id));
        }


    }
}
