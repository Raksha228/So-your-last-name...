using ProductsAppMeF.Models;
using ProductsAppMeF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppMeF.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _entityService = new();
            _products = _entityService.GetProducts().ToList();
        }
        // context
        private EntityService _entityService;
        // search
        private string _searchValue;
        // list
        private List<Product> _products;
        private Product _selectedProduct;

        // Properties
        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));
            }
        }



        // Methods
        private void UpdateView()
        {
            Products = _entityService.GetProducts().ToList();
        }

        // Commands
        public RelayCommand AddProductCommand => new(o =>
        {
            new ProductEditorView(_entityService).ShowDialog();
            UpdateView();
        });
        public RelayCommand UpdateProductCommand => new(o =>
        {
            new ProductEditorView(_entityService, _selectedProduct).ShowDialog();
            UpdateView();
        });
        public RelayCommand DeleteProductCommand => new(o => { _entityService.Delete(_selectedProduct); UpdateView(); });
        public RelayCommand HideProductCommand => new(o => { _entityService.Hide(_selectedProduct); UpdateView(); });
        public RelayCommand ShowProductCommand => new(o => { _entityService.Show(_selectedProduct); UpdateView(); });

    }
}
