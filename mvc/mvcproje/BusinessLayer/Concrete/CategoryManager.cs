using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
      // GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAll()
        //{
        //    return repo.List();
        //}

        //public void CategoryAdd(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 100)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}

        ICategoryDal _categoryDal;

        //constructor
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
             _categoryDal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category); //ID'ye karşılık gelen Category silinir. 
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category); 
        }
        public List<Category> GetList()
        {
            return _categoryDal.List(); //GenericRepository metotlarına ulaşılmış olur. Böylelikle genericrepositorye bağımlılık azalır.
        }
      
    }
}
