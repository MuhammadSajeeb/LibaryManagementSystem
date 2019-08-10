using Lms.Core.Models;
using Lms.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Persistancis.ActionRepositories
{
    public class BooksRepository
    {
        private MainRepository _MainRepository = new MainRepository();
        public decimal AlreadyExistBook(Book _Book)
        {
            string query = "Select Count(*)from Books where Name='"+_Book.Name+"' And CategoriesCode='"+_Book.CategoriesCode+"' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Book _Book)
        {
            string query = "Insert Into Books(Name,AuthorName,AvailableQty,Images,CategoriesCode) Values ('" + _Book.Name + "','" + _Book.AuthorName + "','"+_Book.AvailableQty+"','"+_Book.Images+"','"+_Book.CategoriesCode+"')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        //public int Update(Category _Category)
        //{
        //    string query = "Update Categories SET  Name='" + _Category.Name + "' WHERE Code='" + _Category.Code + "' ";
        //    return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        //}

        public int Delete(Book _Book)
        {
            string query = ("Delete From Books Where Name='"+_Book.Name+"'And CategoriesCode ='" + _Book.CategoriesCode + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<Category> GetAll()
        {
            var _CategoryList = new List<Category>();
            string query = ("Select *From Categories where Status ='Running'");
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
