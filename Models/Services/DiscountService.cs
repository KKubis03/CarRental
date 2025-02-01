using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Models.Services
{
    public class DiscountService : BaseService<DiscountDto, Discount>
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public override void AddModel(Discount model)
        {
            DatabaseContext.Discounts.Add(model);
            if(IsValid(model))
                DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(DiscountDto model)
        {
            Discount discount = DatabaseContext.Discounts.First(item => item.Id == model.Id);
            discount.IsActive = false;
            discount.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Discount GetModel(int id)
        {
            return DatabaseContext.Discounts.First(item => item.Id == id);
        }

        public override List<DiscountDto> GetModels()
        {
            IQueryable<Discount> discounts = DatabaseContext.Discounts.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(Name))
            {
                discounts = discounts.Where(item => item.DiscountName.Contains(Name));
            }
            if (Percentage != 0)
            {
                discounts = discounts.Where(item => item.DiscountPercentage == Percentage);
            }
            if (!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": discounts = !Descending ? discounts.OrderBy(item => item.Id) : discounts.OrderByDescending(item => item.Id); break;
                    case "Name": discounts = !Descending ? discounts.OrderBy(item => item.DiscountName) : discounts.OrderByDescending(item => item.DiscountName); break;
                    case "Percentage": discounts = !Descending ? discounts.OrderBy(item => item.DiscountPercentage) : discounts.OrderByDescending(item => item.DiscountPercentage); break;
                }
            }
            IQueryable<DiscountDto> discountDtos = discounts.Select(item => new DiscountDto()
            {
                Id = item.Id,
                Name = item.DiscountName,
                Percentage = item.DiscountPercentage.ToString()
            });
            return discountDtos.ToList();
        }

        public override void UpdateModel(Discount model)
        {
            DatabaseContext.Discounts.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Discount CreateModel()
        {
            return new Discount()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }

        public override bool IsValid(Discount model)
        {
            if (!model.DiscountName.IsNullOrEmpty() && model.DiscountPercentage > 0 && model.DiscountPercentage <= 100)
                return true;
            else return false;
        }
    }
}
