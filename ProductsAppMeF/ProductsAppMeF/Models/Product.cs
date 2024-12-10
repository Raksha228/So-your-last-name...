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
        public string Title { get; set; } = null!;
        public string? Discription { get; set; }
        public int Amount { get; set; }
        public bool IsHiden { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            var vi = IsHiden ? "Скрытая запись" : "Видемая запись";
            return $"{Title}: {Discription}; {Amount}; {Category}; {vi}";
        }

    }
}
