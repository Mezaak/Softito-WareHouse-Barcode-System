using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> Liste();
        void Userinsert(User U);
        void Userupdate(User U);
        void Userdelete(User U);
        User UserGetById(int id);
    }
}
