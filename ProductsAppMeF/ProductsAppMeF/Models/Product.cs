using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppMeF.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsHiden { get; set; }


        public override string ToString()
        {
            var visibility = IsHiden ? "Скрытая запись" : "Видимая запись";
            return $"{Title} ({Category.Title}): {Description}, {Amount} шт., {visibility}";
        }


        public string FulHi => IsHiden ? "Скрытая запись" : "Видимая запись";
        public string FulGey => $"{Title} / {Category.Title}";
        public string FulNul => $"{Amount} шт.";
    }
}
