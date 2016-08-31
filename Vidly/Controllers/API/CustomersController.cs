using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyMovies.Models;
using VidlyMovies.DTOs;
using AutoMapper;

namespace VidlyMovies.Controllers.API
{
    public class MembershipTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /API/Customers
        public IHttpActionResult GetMembershipTypes()
        {
            return Ok(_context.MembershipTypes.ToList());
        }
    }

    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /API/Customers
        public IHttpActionResult GetCustomersAPI(string query = null)
        {
            var customerQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrEmpty(query))
            {
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));
            }

            var customerDTOs = customerQuery
                .OrderBy(c => c.Name)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDTOs);
        }

        // GET /API/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /API/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.ID = customer.ID;
            return Created(new Uri(Request.RequestUri +"/"+customerDTO.ID),customerDTO);
        }

        // PUT /API/CUstomers
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerInDb);

            _context.SaveChanges();
        }

        // DELETE /API/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
