﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models.Services
{
    public class PaymentService : BaseService<PaymentDto, Payment>
    {
        public int StatusId { get; set; }
        public decimal MinBasePrice { get; set; }
        public decimal MaxBasePrice { get; set; }
        public decimal MinFinalPrice { get; set; }
        public decimal MaxFinalPrice { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? ColumnName { get; set; }
        public override void AddModel(Payment model)
        {
            DatabaseContext.Payments.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(PaymentDto model)
        {
            Payment payment = DatabaseContext.Payments.First(item => item.Id == model.Id);
            payment.IsActive = false;
            payment.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Payment GetModel(int id)
        {
            return DatabaseContext.Payments.First(item => item.Id == id);
        }

        public override List<PaymentDto> GetModels()
        {
            IQueryable<Payment> payments = DatabaseContext.Payments.Where(item => item.IsActive);
            if(StatusId != 0)
            {
                payments = payments.Where(item => item.StatusId == StatusId);
            }
            if(MinBasePrice != 0)
            {
                payments = payments.Where(item => item.Rental.BaseAmount >= MinBasePrice);
            }
            if (MaxBasePrice != 0)
            {
                payments = payments.Where(item => item.Rental.BaseAmount <= MaxBasePrice);
            }
            if (MinFinalPrice != 0)
            {
                payments = payments.Where(item => item.FinalAmount >= MinFinalPrice);
            }
            if (MaxFinalPrice != 0)
            {
                payments = payments.Where(item => item.FinalAmount <= MaxFinalPrice);
            }
            if(DateFrom != null)
            {
                payments = payments.Where(item => item.PaymentDate >= DateFrom);
            }
            if (DateTo != null)
            {
                payments = payments.Where(item => item.PaymentDate <= DateTo);
            }
            if (!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": payments = !Descending ? payments.OrderBy(item => item.Id) : payments.OrderByDescending(item => item.Id); break;
                    case "Status": payments = !Descending ? payments.OrderBy(item => item.Status.StatusName) : payments.OrderByDescending(item => item.Status.StatusName); break;
                    case "Base price": payments = !Descending ? payments.OrderBy(item => item.Rental.BaseAmount) : payments.OrderByDescending(item => item.Rental.BaseAmount); break;
                    case "Final price": payments = !Descending ? payments.OrderBy(item => item.FinalAmount) : payments.OrderByDescending(item => item.FinalAmount); break;
                    case "Discount": payments = !Descending ? payments.OrderBy(item => item.Discount.DiscountName) : payments.OrderByDescending(item => item.Discount.DiscountName); break;
                    case "Rental": payments = !Descending ? payments.OrderBy(item => item.Rental.Id) : payments.OrderByDescending(item => item.Rental.Id); break;
                    case "Date": payments = !Descending ? payments.OrderBy(item => item.PaymentDate) : payments.OrderByDescending(item => item.PaymentDate); break;

                }
            }
            IQueryable<PaymentDto> paymentsDto = payments.Select(item => new PaymentDto()
            {
                Id = item.Id,
                Status = item.Status.StatusName,
                BasePrice = item.Rental.BaseAmount.ToString(),
                FinalPrice = item.FinalAmount.ToString(),
                Discount = item.Discount.DiscountName,
                Rental = item.Rental.Id.ToString(),
                Date = item.PaymentDate
            });
            return paymentsDto.ToList();
        }

        public override void UpdateModel(Payment model)
        {
            DatabaseContext.Payments.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Payment CreateModel()
        {
            return new Payment()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }

        public override bool IsValid(Payment model)
        {
            throw new NotImplementedException();
        }
    }
}
