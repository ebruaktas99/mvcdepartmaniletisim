using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        //CRUD operasyonları tanımlanır.
        //List<Category> Listele();

        //void Insert(Category p); //category sınıfından gelen parametre ile ekleme işlemi gerçekleştirilir.

        //void Update(Category p);
        //void Delete(Category p);
        //List<Category> Listele();
        //List<Category> Listele();
    }
}
