using FA.JustBlog.Models.Common;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Data
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<JustBlogContext>
    {
        protected override void Seed(JustBlogContext context)
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 01",
                    UrlSlug = "category01",
                    Description = "This is Category 01",
                    IsDeleted = false
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 02",
                    UrlSlug = "category02",
                    Description = "This is Category 02",
                    IsDeleted = false
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 03",
                    UrlSlug = "category03",
                    Description = "This is Category 03",
                    IsDeleted = false
                }
            };
            context.Categories.AddRange(categories);

            var post1 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Post 01",
                ShortDescription = "This is Post 01",
                ImageUrl = "blog-3.jpg",
                PostContent = "This is post content 01",
                UrlSlug = "post01",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Category 01"),
                IsDeleted = false,
                ViewCount = 300,
                RateCount = 160,
                TotalRate = 350
            };
            var post2 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Post 02",
                ShortDescription = "This is Post 02",
                ImageUrl = "blog-4.jpg",
                PostContent = "This is post content 02",
                UrlSlug = "post02",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Category 02"),
                IsDeleted = false,
                ViewCount = 700,
                RateCount = 660,
                TotalRate = 1000
            };
            var post3 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Post 03",
                ShortDescription = "This is Post 03",
                ImageUrl = "blog-1.jpg",
                PostContent = "This is post content 03",
                UrlSlug = "post03",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Category 03"),
                IsDeleted = false,
                ViewCount = 400,
                RateCount = 260,
                TotalRate = 400
            };

            var post4 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Post 04",
                ShortDescription = "This is Post 04",
                ImageUrl = "blog-small-1.jpg",
                PostContent = "This is post content 04",
                UrlSlug = "post04",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Category 03"),
                IsDeleted = false,
                ViewCount = 1000,
                RateCount = 1000,
                TotalRate = 3000
            };

            var post5 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Post 05",
                ShortDescription = "This is Post 05",
                ImageUrl = "blog-small-2.jpg",
                PostContent = "This is post content 05",
                UrlSlug = "post05",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Category 02"),
                IsDeleted = false,
                ViewCount = 562,
                RateCount = 397,
                TotalRate = 672
            };

            var post6 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Post 06",
                ShortDescription = "This is Post 06",
                ImageUrl = "blog-small-3.jpg",
                PostContent = "This is post content 06",
                UrlSlug = "post06",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Category 01"),
                IsDeleted = false,
                ViewCount = 973,
                RateCount = 832,
                TotalRate = 1631
            };

            var tags = new List<Tag>()
            {
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tag 01",
                    UrlSlug = "tag01",
                    Description="This is Tag 01",
                    Count = 2,
                    Posts = new List<Post>(){post1,post2,post4},
                    IsDeleted = false
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tag 02",
                    UrlSlug = "tag02",
                    Description="This is Tag 02",
                    Count = 2,
                    Posts = new List<Post>(){post1,post3,post5},
                    IsDeleted = false
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tag 03",
                    UrlSlug = "tag03",
                    Description="This is Tag 03",
                    Count = 3,
                    Posts = new List<Post>(){post4,post5, post6},
                    IsDeleted = false
                }
            };

            context.Tags.AddRange(tags);
            context.SaveChanges();
        }
    }
}