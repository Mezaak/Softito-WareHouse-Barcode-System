using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstarct;
using Data.EntityFramework;
using Entity.Concreate;

namespace Business.Concreate
{
    internal class UserManager : IUserService
    {
        IUserDal _UserDal;
        public List<User> Liste()
        {
            return _UserDal.GetAll();
        }

        public void Userdelete(User U)
        {
            _UserDal.Delete(U);
        }

        public User UserGetById(int id)
        {
            return _UserDal.Get(x => x.UserId == id);
        }


        public void Userinsert(User U)
        {
            _UserDal.Insert(U);
        }

        public void Userupdate(User U)
        {
           _UserDal.Update(U);
        }
    }
}
