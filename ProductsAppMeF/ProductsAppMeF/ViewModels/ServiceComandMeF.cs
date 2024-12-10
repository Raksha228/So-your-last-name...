using Microsoft.EntityFrameworkCore;
using ProductsAppMeF.DbCore;
using ProductsAppMeF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppMeF.ViewModels
{
    internal class ServiceComandMeF
    {
        private AppDbContext _ctx;
        public ServiceComandMeF(AppDbContext ctx) { _ctx = ctx; }
        public ServiceComandMeF() { _ctx = new AppDbContext(); }

        ~ServiceComandMeF() { Debug.WriteLine("Destructer Called:"); }

        public ICollection<Product> GetProducts() => _ctx.Products.Include(p => p.Category).ToList();
        public ICollection<Category> GetCategories() => _ctx.Categorys.ToList();



        //Addы
        public Category Add(string title, string? description, bool isHiden = false)
        {
            try
            {
                var category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Discription = description,
                    IsHiden = isHiden
                };

                _ctx.Categorys.Add(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"New category {title} added!");
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;

            }
        }
        
        public Product Add(string title, string? discription, int amount, Category category ,bool isHiden = false)
        {
            try
            {
                var product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Discription = discription,
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
                return null;

            }
        }

        //UpDateы
        public Category Update(Category category, string title, string? description, bool isHiden)
        {
            try
            {
                category.Title = title;
                category.Discription = description;
                category.IsHiden = isHiden;
                _ctx.Categorys.Update(category);
                _ctx.SaveChanges();

                Debug.WriteLine($"category {title} Update!");
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;

            }
        }
        
        public Product Update(Product product,string title, string? discription, int amount, Category category, bool isHiden = false)
        {
            try
            {
                product.Title = title;
                product.Discription = discription;  
                product.Amount = amount;
                product.Category = category;
                product.IsHiden = isHiden;

                _ctx.Products.Update(product);
                _ctx.SaveChanges();

                Debug.WriteLine($"Product {title} Update!");
                return product;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //DelateЫ
        public void Delete(Category category)
        {
            try
            {
                _ctx.Categorys.Remove(category);
                _ctx.SaveChanges();
                Debug.WriteLine($"category {category.Title} Delate!");
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
                Debug.WriteLine($"product {product.Title} Delate!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //HidenЫ
        public void Hide(Category category)
        {
            try
            {
                if (category.IsHiden == false)
                {
                    category.IsHiden = true;

                    _ctx.Categorys.Update(category);
                    _ctx.SaveChanges();
                    Debug.WriteLine($"category {category.Title} Delate!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void Hide(Product product)
        {
            try
            {
                if (product.IsHiden == false)
                {
                    product.IsHiden = true;

                    _ctx.Products.Update(product);
                    _ctx.SaveChanges();
                    Debug.WriteLine($"category {product.Title} Delate!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //ShowЫ
        public void Show(Category category)
        {
            try
            {
                if (category.IsHiden == true)
                {
                    category.IsHiden = false;

                    _ctx.Categorys.Update(category);
                    _ctx.SaveChanges();
                    Debug.WriteLine($"category {category.Title} Delate!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void Show(Product product)
        {
            try
            {
                if (product.IsHiden == true)
                {
                    product.IsHiden = false;

                    _ctx.Products.Update(product);
                    _ctx.SaveChanges();
                    Debug.WriteLine($"category {product.Title} Delate!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }



    }
}
