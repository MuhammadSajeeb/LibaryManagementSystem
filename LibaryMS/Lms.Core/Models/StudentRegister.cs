using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Models
{
    public class StudentRegister
    {
        public int Id { get; set; }
        public string EnrollId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

    }
}
