using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void CategoryInsert(Category category);
        void CategoryUpdate(Category category);
        void CategoryDelete(Category category);
        Category CategoryGetById(int id);
    }
}
