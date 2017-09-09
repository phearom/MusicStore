using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Repository<T> where T : class
    {
        private MusicStoreDataContext context = new MusicStoreDataContext();

        public Repository() { }
        public DbSet<T> DbSet
        {
            get
            {
                return context.Set<T>();
            }
        }
        public T GetById(int? id)
        {
            return context.Set<T>().Find(id);
        }
        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void DeleteById(int? id)
        {
            context.Set<T>().Remove(GetById(id));
        }
        public int SaveChange()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}