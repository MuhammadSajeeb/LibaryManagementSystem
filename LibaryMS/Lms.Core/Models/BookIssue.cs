using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Models
{
    public class BookIssue
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int BookQty { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string EnrollId { get; set; }
        public string CategoriesCode { get; set; }
        public string AdminStatus { get; set; }
        public string StudentStatus { get; set; }

    }
}
