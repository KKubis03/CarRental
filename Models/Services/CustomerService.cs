using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Models.Services
{
    public class CustomerService : BaseService<CustomerDto, Customer>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override void AddModel(Customer model)
        {
            DatabaseContext.Customers.Add(model);
            if(IsValid(model))
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
            if (!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": customers = !Descending ? customers.OrderBy(item => item.Id) : customers.OrderByDescending(item => item.Id); break;
                    case "Name": customers = !Descending ? customers.OrderBy(item => item.FirstName) : customers.OrderByDescending(item => item.FirstName); break;
                    case "Surname": customers = !Descending ? customers.OrderBy(item => item.LastName) : customers.OrderByDescending(item => item.LastName); break;
                    case "Phone": customers = !Descending ? customers.OrderBy(item => item.PhoneNumber) : customers.OrderByDescending(item => item.PhoneNumber); break;
                    case "Email": customers = !Descending ? customers.OrderBy(item => item.Email) : customers.OrderByDescending(item => item.Email); break;
                }
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

        public override bool IsValid(Customer model)
        {
            if (!model.FirstName.IsNullOrEmpty() && !model.FirstName.Any(char.IsDigit) && !model.LastName.IsNullOrEmpty() && !model.LastName.Any(char.IsDigit) && !model.PhoneNumber.IsNullOrEmpty() 
                && model.PhoneNumber.All(char.IsDigit) && !model.Email.IsNullOrEmpty())
                return true;
            else return false;
        }
    }
}
