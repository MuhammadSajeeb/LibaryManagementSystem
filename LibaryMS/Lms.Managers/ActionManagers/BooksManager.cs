using Lms.Core.Models;
using Lms.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Managers.ActionManagers
{
    public class BooksManager
    {
        private BooksRepository _BooksRepository = new BooksRepository();

        public decimal AlreadyExistBook(Book _Book)
        {
            return _BooksRepository.AlreadyExistBook(_Book);
        }
        public int Add(Book _Book)
        {
            return _BooksRepository.Add(_Book);
        }
        public int Delete(Book _Book)
        {
            return _BooksRepository.Delete(_Book);
        }
        public List<Category> GetAll()
        {
            return _BooksRepository.GetAll();
        }
    }
}
