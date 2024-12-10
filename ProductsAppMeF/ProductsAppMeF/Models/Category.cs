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
        public string? Discription { get; set; }


        public bool IsHiden { get; set; }


        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            var vi = IsHiden ? "Скрытая запись" : "Видемая запись";
            return $"{Title}: {Discription}; {vi}";
        }

    }
}
