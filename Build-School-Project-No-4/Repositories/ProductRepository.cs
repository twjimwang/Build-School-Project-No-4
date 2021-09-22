using Build_School_Project_No_4.DataModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace Build_School_Project_No_4.Services
{
    public class ProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository()
        {
            _context = new EPalContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Create<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Added;
        }
        public void Update<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Modified;
        }
        public void Delete<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Deleted;
        }
        //public IQueryable<T> GetAll<T, Tkey>(Expression<Func<T, Tkey>> keyselector) where T : class
        //{
        //    return _context.Set<T>().OrderBy(keyselector);
        //}
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}