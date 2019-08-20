using Lms.Core.Models;
using Lms.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Managers.ActionManagers
{
    public class StudentRegisterManager
    {
        private StudentRegisterRepository _StudentRegisterRepository = new StudentRegisterRepository();

        public decimal AlreadyRegister(StudentRegister _StudentRegister)
        {
            return _StudentRegisterRepository.AlreadyRegister(_StudentRegister);
        }
        public int Register(StudentRegister _StudentRegister)
        {
            return _StudentRegisterRepository.Register(_StudentRegister);
        }
        public decimal Login(StudentRegister _StudentRegister)
        {
            return _StudentRegisterRepository.Login(_StudentRegister);
        }
        public decimal CheckStatus(StudentRegister _StudentRegister)
        {
            return _StudentRegisterRepository.AlreadyRegister(_StudentRegister);
        }
    }
}
