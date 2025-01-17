using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using CarRental.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CarRental.Models.Services
{
    public class ReviewService : BaseService<ReviewDto, Review>
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public override void AddModel(Review model)
        {
            DatabaseContext.Reviews.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ReviewDto model)
        {
            Review review = GetModel(model.Id);
            review.IsActive = false;
            review.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Review GetModel(int id)
        {
            return DatabaseContext.Reviews.First(item => item.Id == id);
        }

        public override List<ReviewDto> GetModels()
        {
            IQueryable<Review> reviews = DatabaseContext.Reviews.Where(item => item.IsActive);
            if(!string.IsNullOrEmpty(Content))
            {
                reviews = reviews.Where(item => item.Content.Contains(Content));
            }
            if(Rating != 0)
            {
                reviews = reviews.Where(item => item.Rating == Rating);
            }
            IQueryable<ReviewDto> reviewsDto = reviews.Select(item => new ReviewDto()
            {
                Id = item.Id,
                Text = item.Content,
                Rating = item.Rating.ToString(),
                Rental = item.RentalId.ToString()
            });
            return reviewsDto.ToList();
        }

        public override void UpdateModel(Review model)
        {
            DatabaseContext.Reviews.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Review CreateModel()
        {
            return new Review()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }
    }
}
