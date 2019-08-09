using Lms.Core.Models;
using Lms.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Managers.ActionManagers
{
    public class CategoriesManager
    {
        private CategoriesRepository _CategoriesRepository = new CategoriesRepository();
        public decimal AlreadyExistData()
        {
            return _CategoriesRepository.AlreadyExistData();
        }
        public Category GetLastCode()
        {
            return _CategoriesRepository.GetLastCode();
        }
        public int Add(Category _Category)
        {
            return _CategoriesRepository.Add(_Category);
        }
        public int Update(Category _Category)
        {
            return _CategoriesRepository.Update(_Category);
        }
        public int Delete(Category _Category)
        {
            return _CategoriesRepository.Delete(_Category);
        }
        public List<Category> GetAll()
        {
            return _CategoriesRepository.GetAll();
        }
        public List<Category> GetAllWithStatus()
        {
            return _CategoriesRepository.GetAllWithStatus();
        }
    }
}
