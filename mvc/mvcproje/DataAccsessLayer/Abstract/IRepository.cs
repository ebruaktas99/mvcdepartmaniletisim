using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface IRepository<T>
    {
        //Tek tek kategori için vs ekleme silme işlemlerini yapmaktansa bu şekilde hepsi için yapılır.
        List<T> List();
        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter); //get isimli metot tanımlanır. 
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter); //şartlı listeleme
    }
}
