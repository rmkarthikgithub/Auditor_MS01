﻿using MC18_S1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC18_S1
{
    public class DataAccessRepository<T> : IDataAccess<T> where T : class
    {
        AuditorUserContext ctx;
        private DbSet<T> dbset;
        public DataAccessRepository()
        {
            ctx = new AuditorUserContext();
            dbset = ctx.Set<T>();
        }
        public DataAccessRepository(AuditorUserContext c)
        {
            ctx = c;
            dbset = ctx.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public T GetById(object id)
        {
            return dbset.Find(id);
        }
        public void Insert(T obj)
        {
            dbset.Add(obj);
            Save();
        }
        public void Update(T obj)
        {
            dbset.Attach(obj);
            ctx.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(object id)
        {
            T existing = dbset.Find(id);
            dbset.Remove(existing);
            Save();
        }
        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
