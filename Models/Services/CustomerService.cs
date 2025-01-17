using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models.Services
{
    public class CustomerService : BaseService<CustomerDto, Customer>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override void AddModel(Customer model)
        {
            DatabaseContext.Customers.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(CustomerDto model)
        {
            Customer customer = DatabaseContext.Customers.First(item => item.Id == model.Id);
            customer.IsActive = false;
            customer.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Customer GetModel(int id)
        {
            return DatabaseContext.Customers.First(item => item.Id == id);
        }

        public override List<CustomerDto> GetModels()
        {
            IQueryable<Customer> customers = DatabaseContext.Customers.Where(item => item.IsActive);
            if(!string.IsNullOrEmpty(Name))
            {
                customers = customers.Where(item => item.FirstName.Contains(Name));
            }
            if (!string.IsNullOrEmpty(Surname))
            {
                customers = customers.Where(item => item.LastName.Contains(Surname));
            }
            IQueryable<CustomerDto> customersDto = customers.Select(item => new CustomerDto()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email
            });
            return customersDto.ToList();
        }

        public override void UpdateModel(Customer model)
        {
            DatabaseContext.Customers.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Customer CreateModel()
        {
            return new Customer()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }
    }
}
