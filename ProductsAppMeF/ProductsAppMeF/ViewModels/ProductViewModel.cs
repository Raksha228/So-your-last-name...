using ProductsAppMeF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppMeF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        public ProductViewModel(Product? product, EntityService service)
        {
            _service = service;
            categories = service.GetCategories().ToList();
            if (product != null)
            {
                Title = product.Title;
                Description = product.Description;
                SelectedCategory = product.Category;
                Amount = product.Amount;
                IsHiden = product.IsHiden;

                SaveCommand = new(o =>
                {
                    _service.Update(product, title, description, amount, selectedCategory, isHiden);
                });
            }
            else
            {
                product = new();
                SaveCommand = new(o =>
                {
                    _service.Add(title, description, amount, selectedCategory, isHiden);
                    
                    
                });
                
            }

        }
        private EntityService _service;

        private string title;
        private string description;
        private Category selectedCategory;
        private List<Category> categories;
        private int amount;
        private bool isHiden;

        public string Title
        {
            get => title; set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Description
        {
            get => description; set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public Category SelectedCategory
        {
            get => selectedCategory; set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        public List<Category> Categories
        {
            get => categories; set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public int Amount
        {
            get => amount; set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public bool IsHiden
        {
            get => isHiden; set
            {
                isHiden = value;
                OnPropertyChanged(nameof(IsHiden));
            }
        }
        public RelayCommand SaveCommand { get; }
    }
}
