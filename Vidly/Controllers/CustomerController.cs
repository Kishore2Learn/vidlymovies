using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMovies.Models;
using VidlyMovies.ViewModels;

namespace VidlyMovies.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var modelName = User.IsInRole(VidlyRoles.CanManageRole) ? "List":"ReadOnly";
            return View(modelName, _context.Customers.Include(c => c.MembershipType).OrderBy(c => c.ID));
        }

        public ActionResult Details(int? id)
        {
            Customer selectedCustomer = null;
            if (id.HasValue)
            {
                var customerID = id.GetValueOrDefault(0);
                selectedCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == customerID);
                if (selectedCustomer != null)
                {
                    ViewBag.ContainData = "1";
                    return View(selectedCustomer);
                }
                else
                {
                    ViewBag.ContainData = "0";
                    ViewBag.Description = "Customer details for Customer ID " + customerID + " not found.";
                    return View();
                }
            }
            else
            {
                ViewBag.ContainData = "2";
                ViewBag.Description = "Please select any customer to view details.";
                return View();
            }
        }

        [Authorize(Roles = VidlyRoles.CanManageRole)]
        public ActionResult New()
        {
            var newCustomerFormViewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            ViewBag.New = true;
            return View("CustomerForm",newCustomerFormViewModel);
        }

        [Authorize(Roles = VidlyRoles.CanManageRole)]
        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            var userName = User.Identity.GetUserName();
            if (customer == null)
                return HttpNotFound();


            var newCustomerFormViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            ViewBag.New = false;
            return View("CustomerForm", newCustomerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = VidlyRoles.CanManageRole)]
        public ActionResult Save(Customer customer)
        {
            ViewBag.New = (customer.ID == 0);
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.ID == 0)
            {
                ViewBag.Description = "New Customer Details Saved Successfully For ";
                _context.Customers.Add(customer);
            }
            else
            {
                var customerFromDB = _context.Customers.SingleOrDefault(c => c.ID == customer.ID);
                customerFromDB.Name = customer.Name;
                customerFromDB.MembershipTypeID = customer.MembershipTypeID;
                customerFromDB.BirthDate = customer.BirthDate;
                customerFromDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                ViewBag.Description = "Customer Details Updated Successfully For ";
            }
            _context.SaveChanges();

            ViewBag.ContainData = "1";
            return View("UpdatedDetails",customer);
        }

        [Authorize(Roles = VidlyRoles.CanManageRole)]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var customerID = id.GetValueOrDefault(0);
                var selectedCustomer = _context.Customers.Single(c => c.ID == customerID);
                if (selectedCustomer != null)
                {
                    ViewBag.ContainData = "2";
                    _context.Customers.Remove(selectedCustomer);
                    _context.SaveChanges();
                    ViewBag.Description = selectedCustomer.Name + " Customer deleted";
                    return View("UpdatedDetails");
                }
                else
                {
                    
                    ViewBag.ContainData = "2";
                    ViewBag.Description = "Customer details for Customer ID " + customerID + " not found.";
                    return View("UpdatedDetails");
                }
            }
            else
            {
                ViewBag.ContainData = "2";
                ViewBag.Description = "Please select any customer to delete.";
                return View("UpdatedDetails");
            }
        }

    }
}