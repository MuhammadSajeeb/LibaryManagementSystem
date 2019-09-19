using Lms.Core.Models;
using Lms.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Persistancis.ActionRepositories
{
    public class BookIssueRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal CountReceivedBook(BookIssue _BookIssue)
        {
            string query = "Select Count(*)from BookIssue where EnrollId='" + _BookIssue.EnrollId + "' And AdminStatus='Received' And Month(IssueDate)='" + DateTime.Now.Month + "' And Year='"+DateTime.Now.Year+"' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal CountIssuedBook(BookIssue _BookIssue)
        {
            string query = "Select Count(*)from BookIssue where EnrollId='" + _BookIssue.EnrollId + "' And AdminStatus='Issued' And Month(IssueDate)='" + DateTime.Now.Month + "' And Year='" + DateTime.Now.Year + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal AlreadyIssueBook(BookIssue _BookIssue)
        {
            string query = "Select Count(*)from BookIssue where BookName='"+_BookIssue.BookName+ "' And EnrollId='" + _BookIssue.EnrollId + "' And CategoriesCode='" + _BookIssue.CategoriesCode+"' And AdminStatus='Pending' And Month(IssueDate)='" + DateTime.Now.Month + "' And Year='" + DateTime.Now.Year + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal CheckBoookQty(Book _Book)
        {
            string query = "Select Count(*)from Books where Name='"+_Book.Name+"' And AvailableQty='" + _Book.AvailableQty + "' And CategoriesCode='" + _Book.CategoriesCode + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Book CheckBoookQty(string Name,decimal qty,string categoriescode)
        {
            Book _Book = null;

            string query = "Select Count(*)from Books where Name='" + Name + "' And AvailableQty='" + qty + "' And CategoriesCode='" + categoriescode + "' ";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Book = new Book();
                _Book.AvailableQty = Convert.ToDecimal(reader["AvailableQty"]);
            }
            reader.Close();

            return _Book;
        }
    }
}
