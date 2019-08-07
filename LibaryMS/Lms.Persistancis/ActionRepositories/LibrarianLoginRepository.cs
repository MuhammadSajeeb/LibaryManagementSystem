using Lms.Core.Models;
using Lms.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Persistancis.ActionRepositories
{
    public class LibrarianLoginRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal Login(LibrarianLogin _LibrarianLogin)
        {
            string query = "Select Count(*)from LibrarianLogin where UserName='" + _LibrarianLogin.UserName + "' And Password='" + _LibrarianLogin.Password + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
    }
}
