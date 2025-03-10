using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstarct;
using Data.Concreate;
using Entity.Concreate;

namespace Data.EntityFramework
{
    public class EFUserDal : GenericRepository<User>,IUserDal
    {
    }
}
