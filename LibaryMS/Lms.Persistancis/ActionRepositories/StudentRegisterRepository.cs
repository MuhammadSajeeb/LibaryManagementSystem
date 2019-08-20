using Lms.Core.Models;
using Lms.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Persistancis.ActionRepositories
{
    public class StudentRegisterRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyRegister(StudentRegister _StudentRegister)
        {
            string query = "Select Count(*)from StudentRegister where EnrollId='" + _StudentRegister.EnrollId + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Register(StudentRegister _StudentRegister)
        {
            string query = "Insert Into StudentRegister(EnrollId,Email,Password,Status) Values ('" + _StudentRegister.EnrollId+ "','" + _StudentRegister.Email + "','" + _StudentRegister.Password + "','Pending')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public decimal Login(StudentRegister _StudentRegister)
        {
            string query = "Select Count(*)from StudentRegister where EnrollId='" + _StudentRegister.EnrollId + "' And Password='"+_StudentRegister.Password+"' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal CheckStatus(StudentRegister _StudentRegister)
        {
            string query = "Select Count(*)from StudentRegister where EnrollId='" + _StudentRegister.EnrollId + "' And Password='" + _StudentRegister.Password + "' And Status='Running' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
    }
}
