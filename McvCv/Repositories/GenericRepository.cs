﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using McvCv.Models.Entity;

namespace McvCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        dinamikCvDBEntities db = new dinamikCvDBEntities();

        public List<T> list()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TRemove(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

    }
}