using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellBook_Data;
using System.Data.Entity;

namespace SellBook_Services
{
    public class PublicationService : IPublicationService
    {
        private readonly ISellbookDbContext context;

        public PublicationService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public ICollection<Publication> GetLatest()
        {
            return this.context.Publication
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.AddedOn)
                .Take(20)
                .Include(x => x.Images)
                .ToList();
        }

        public Guid Add(Guid userId, Guid categoryID, Guid subCategory, string title, string description, string phoneNumber, Guid DetailsId, Guid CityId, Guid RegionId)
        {
            var id = Guid.NewGuid();

            this.context.Publication.Add(new Publication()
            {
                Id = id,
                AddAssFavourite = 0,
                AddedOn = DateTime.Now,
                ApplicationUserId = userId.ToString(),
                CategoryId = categoryID,
                Description = description,
                //IsContracting = isContracting,
                PhoneNumber = phoneNumber,
                //Price = price,
                SubCategoryId = subCategory,
                Title = title,
                ViewPhone = 0,
                Views = 0,
                PublicationDetailsId = DetailsId,
                IsActive = true,
                IsArchived = false,
                IsDeleted = false,
                CityId = CityId,
                RegionId = RegionId
            });

            this.context.SaveChanges();

            return id;
        }

        public Publication GetPublicationById(Guid Id)
        {
            return this.context.Publication.Where(x => x.Id == Id).Include(x => x.Images).Include(x => x.Category).FirstOrDefault();
        }

        public void UpdateDetailPublicationId(Guid PublicationId, Guid DetailsId)
        {
            var publication = this.context.Publication.FirstOrDefault(x => x.Id == PublicationId);

            if(publication != null)
            {
                publication.PublicationDetailsId = DetailsId;

                this.context.SaveChanges();
            }
        }

        public bool IsContains(Guid id)
        {
            var publication = this.context.Publication.FirstOrDefault(x => x.Id == id);

            if(publication != null)
            {
                return true;
            }

            return false;
        }

        public int AllPublication()
        {
            return this.context.Publication
                .Where(x => x.IsActive == true)
                .Count();
        }

        public ICollection<Publication> GetByQuery(string Query, Guid? RegionId, Guid? CategoryId)
        {
            var Publications = new List<Publication>();

            if(RegionId != null && CategoryId != null)
            {
                Publications = this.context.Publication.Where(x => x.RegionId == RegionId &&
                x.CategoryId == CategoryId && x.IsActive == true).Include(x => x.Images).ToList();
            }
            else
            {
                if(RegionId != null)
                {
                    Publications = this.context.Publication.Where(x => x.RegionId == RegionId && x.IsActive == true).Include(x => x.Images).ToList();
                }
                else if(CategoryId != null)
                {
                    Publications = this.context.Publication.Where(x => x.CategoryId == CategoryId && x.IsActive == true).Include(x => x.Images).ToList();
                }
                else
                {
                    Publications = this.context.Publication. Where(x => x.IsActive == true).Include(x => x.Images).ToList();
                }
            }
        
            var result = new List<Publication>();
            string[] SearchedWords = Query.Split(' ').ToArray();

            foreach (var publication in Publications)
            {
                var TitleWords = publication.Title.Split(' ').ToArray();

                bool isPassed = false;

                foreach (var word in SearchedWords)
                {
                    foreach (var item in TitleWords)
                    {
                        if(word.ToLower() == item.ToLower())
                        {
                            isPassed = true;
                            break;
                        }
                    }
                }

                if (isPassed)
                {
                    result.Add(publication);
                }
            }

            return result;
        }

        public ICollection<Publication> GetPublicatrionsForUser(string UserId)
        {
            return this.context.Publication
                .Where(x => x.ApplicationUserId == UserId)
                .Include(x => x.Images)
                .ToList();
        }

        public void ActivatePublication(Guid id)
        {
            var publication = this.context.Publication.FirstOrDefault(x => x.Id == id);

            if (publication != null)
            {
                publication.IsActive = true;
                publication.IsArchived = false;

                this.context.SaveChanges();
            }
        }

        public ICollection<Publication> GetArchivedPublications(string UserId)
        {
            return this.context.Publication.Where(x => x.ApplicationUserId == UserId && x.IsArchived == true)
                .Include(x => x.Images).ToList();
        }

        public ICollection<Publication> GetOtherPublicationForUser(string userId, Guid PublicationId)
        {
            return this.context.Publication
                .Where(x => x.ApplicationUserId == userId && x.IsActive == true && x.Id != PublicationId)
                .Include(x => x.Images)
                .ToList();
        }
    }
}
