using DataAccsessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //T değeri class olmalı.

        Context c = new Context();
        DbSet<T> _object; //object T değerine karşılık gelen sınıfı tutar. T Değerine karşılık gelen sınıf constructor ile bulunur.

        //constructor
        public GenericRepository()
        {
            _object = c.Set<T>(); //Contexte bağlı olarak gelen T değerini alır.
        }
        public void Delete(T p)
        {
            //ENTİTY STATE
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //Bir dizide veya listede sadece bir değer döndürmeyi sağlar.
        }

        public void Insert(T p)
        {
            //ENTİTY STATE 
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();

        }
        
        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            //ENTİTY STATE 
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
