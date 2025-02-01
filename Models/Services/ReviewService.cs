using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using CarRental.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Models.Services
{
    public class ReviewService : BaseService<ReviewDto, Review>
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public override void AddModel(Review model)
        {
            DatabaseContext.Reviews.Add(model);
            if(IsValid(model))
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
            if (!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": reviews = !Descending ? reviews.OrderBy(item => item.Id) : reviews.OrderByDescending(item => item.Id); break;
                    case "Content": reviews = !Descending ? reviews.OrderBy(item => item.Content) : reviews.OrderByDescending(item => item.Content); break;
                    case "Rating": reviews = !Descending ? reviews.OrderBy(item => item.Rating) : reviews.OrderByDescending(item => item.Rating); break;
                    case "RentalId": reviews = !Descending ? reviews.OrderBy(item => item.RentalId) : reviews.OrderByDescending(item => item.RentalId); break;
                }
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

        public override bool IsValid(Review model)
        {
            if (!model.Content.IsNullOrEmpty() && model.RentalId != 0 && model.Rating > 0 && model.Rating <= 5)
                return true;
            else return false;
        }
    }
}
