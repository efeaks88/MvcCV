using Microsoft.Ajax.Utilities;
using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MvcCV.Repositories
{
    //T değeri attık bu T değeri sınıf göndermek için. Şart belirtip sınf olmalı ve özelliklerini almalı dedik.
    //newlenebilir olmalı dedik.
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
            //gelcek t değerini tolist olarak döndüreüyor gelen t değeri zaten bir sınıf olacağı için sql tablolarımız direk geliyor
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>>where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}