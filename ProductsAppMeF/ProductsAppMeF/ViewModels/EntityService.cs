using Microsoft.EntityFrameworkCore;
using ProductsAppMeF.DbCore;
using ProductsAppMeF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppMeF.ViewModels
{
    public class EntityService
    {
        private AppDbContext _ctx;
        public EntityService(AppDbContext ctx) { _ctx = ctx; }
        public EntityService() { _ctx = new AppDbContext(); }
        ~EntityService() { Debug.WriteLine("Destructor called!"); }
        // GetData
        public ICollection<Product> GetProducts() => _ctx.Products.Include(p => p.Category).ToList();
        public ICollection<Category> GetCategories() => _ctx.Categories.ToList();
        // Add
        public Category Add(string title, string? description, bool isHiden = false)
        {
            try
            {
                var category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Description = description,
                    IsHiden = isHiden
                };
                _ctx.Categories.Add(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"New category {title} added!");
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        public Product Add(string title, string? description, int amount, Category category, bool isHiden = false)
        {
            try
            {
                var product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Description = description,
                    Amount = amount,
                    Category = category,
                    IsHiden = isHiden
                };
                _ctx.Products.Add(product);
                _ctx.SaveChanges();
                Debug.WriteLine($"New product {title} added!");
                return product;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        // Update
        public Category Update(Category category, string title, string? description, bool isHiden)
        {
            try
            {
                category.Title = title;
                category.Description = description;
                category.IsHiden = isHiden;
                _ctx.Categories.Update(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"Category {title} updated!");
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        public Product Update(Product product, string title, string? description, int amount, Category category, bool isHiden)
        {
            try
            {
                product.Title = title;
                product.Description = description;
                product.Amount = amount;
                product.Category = category;
                product.IsHiden = isHiden;
                _ctx.Products.Update(product);
                _ctx.SaveChanges();
                Debug.WriteLine($"Product {title} update!");
                return product;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        // Delete
        public void Delete(Category category)
        {
            try
            {
                _ctx.Categories.Remove(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"Category {category.Title} deleted!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void Delete(Product product)
        {
            try
            {
                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
                Debug.WriteLine($"Product {product.Title} deleted!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        // Hide
        public Category Hide(Category category)
        {
            try
            {
                category.IsHiden = true;
                _ctx.Categories.Update(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"Category {category.Title} hided!");
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        public Product Hide(Product product)
        {
            try
            {
                product.IsHiden = true;
                _ctx.Products.Update(product);
                _ctx.SaveChanges();
                Debug.WriteLine($"Product {product.Title} hided!");
                return product;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        // Show
        public Category Show(Category category)
        {
            try
            {
                category.IsHiden = false;
                _ctx.Categories.Update(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"Category {category.Title} showed!");
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
        public Product Show(Product product)
        {
            try
            {
                product.IsHiden = false;
                _ctx.Products.Update(product);
                _ctx.SaveChanges();
                Debug.WriteLine($"Product {product.Title} showed!");
                return product;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }




    }
}
