using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;

namespace CarRental.Models.Services
{
    public class DiscountService : BaseService<DiscountDto, Discount>
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public override void AddModel(Discount model)
        {
            DatabaseContext.Discounts.Add(model);
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
    }
}
