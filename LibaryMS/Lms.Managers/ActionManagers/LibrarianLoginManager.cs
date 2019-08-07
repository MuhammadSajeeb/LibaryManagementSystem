using Lms.Core.Models;
using Lms.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Managers.ActionManagers
{
    public class LibrarianLoginManager
    {
        private LibrarianLoginRepository _LibrarianLoginRepository = new LibrarianLoginRepository();

        public decimal Login(LibrarianLogin _LibrarianLogin)
        {
            return _LibrarianLoginRepository.Login(_LibrarianLogin);
        }
    }
}
