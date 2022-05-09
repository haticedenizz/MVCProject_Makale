using Makale.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Makale.DataAccessLayer
{
    public class Respository<T> where T:class

    {
        DatabaseContext db = new DatabaseContext();
        private DbSet<T> _dbset;
        public Respository()
        {
            _dbset = db.Set<T>();
        }
        public List<T> List()
        {
            return _dbset.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> kosul)
        {
            return _dbset.Where(kosul).ToList();
        }
        public int Insert(T nesne)
        {

            _dbset.Add(nesne);
            if(nesne is EntitiesBase)
            {
                EntitiesBase obje = nesne as EntitiesBase;
                obje.ModifiedDate = DateTime.Now;
                obje.CreateDate = DateTime.Now;
                obje.ModifiedUsername = "";
            }
            return Save();
        }
        public int Delete(T nesne)
        {

            _dbset.Add(nesne);
            return Save();
        }
        public int Update()
        {

            return Save();
        }

        private int Save()
        {
            return db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> kosul)
        {

           return _dbset.FirstOrDefault(kosul);
        }
    }
}
