using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public decimal AvailableQty { get; set; }
        public String Images { get; set; }
        public string CategoriesCode { get; set; }
        public string Status { get; set; }
    }
}
