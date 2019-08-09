using Lms.Core.Models;
using Lms.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Persistancis.ActionRepositories
{
    public class CategoriesRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistData()
        {
            string query = "Select Count(*)from Categories ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Category GetLastCode()
        {
            Category _Categories = null;

            string query = "Select top 1 Code from Categories order by Code desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Categories = new Category();
                _Categories.Code =(reader["Code"].ToString());
            }
            reader.Close();

            return _Categories;
        }
        public int Add(Category _Category)
        {
            string query = "Insert Into Categories(Code,Name,Status) Values ('" + _Category.Code + "','" + _Category.Name + "','Running')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Update(Category _Category)
        {
            string query = "Update Categories SET  Name='" + _Category.Name + "' WHERE Code='" + _Category.Code + "' ";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public int Delete(Category _Category)
        {
            string query = ("Delete From Categories Where Code ='" + _Category.Code + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public List<Category> GetAll()
        {
            var _CategoryList = new List<Category>();
            string query = ("Select *From Categories");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Category = new Category();
                    _Category.Code = (reader["Code"].ToString());
                    _Category.Name = reader["Name"].ToString();

                    _CategoryList.Add(_Category);
                }
            }
            reader.Close();

            return _CategoryList;
        }
    }
}
