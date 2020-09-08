using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Repository
{
    public class EFRepository <TEntity> : IGenericRepository <TEntity> where TEntity : class //Обмеження на тип
    {
        public readonly DbContext context;
        private readonly DbSet<TEntity> set;

   


        public EFRepository()
        {
            context = new ApplicationContext();
            set = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            //1. Варіант
            //context.Set<TEntity>().Add(entity);


            //2. Варіант, створюємо  private readonly DbSet<TEntity> set + в конструкторі робимо  set = context.Set<TEntity>();
            set.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return set.AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //set.AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
