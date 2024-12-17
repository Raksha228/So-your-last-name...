using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppMeF.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsHiden { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            var visibility = IsHiden ? "Скрытая запись" : "Видимая запись";
            return $"{Title}: {Description}, {visibility}";
        }



    }
}
