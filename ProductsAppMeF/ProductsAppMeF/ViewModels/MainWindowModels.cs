using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsAppMeF.DbCore;
using ProductsAppMeF.Models;
using ProductsAppMeF.Views;

namespace ProductsAppMeF.ViewModels
{
    class MainWindowModels : ViewModelBase
    {
        public MainWindowModels()
        {
            

            CreateCommand = new RelayCommand(o =>
            {

                OpenWindowDialog(new ProductEditorView());

            });



        }


        public RelayCommand CreateCommand { get; }
        public RelayCommand CreateCategoryCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand HideCommand { get; }
        public RelayCommand ShowCommand { get; }
        public RelayCommand ExecuteCommand { get; }
        public RelayCommand WindowCloseCommand { get; }



    }
}
