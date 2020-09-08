using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //Опис методів, що доступні в нашій базі

       //Метод Create
        void Create(TEntity entity);
        //Метод Read
        IEnumerable<TEntity> GetAll();
        //Метод Remove
        void Delete(TEntity entity);
        //Мутод Update
        void Update(TEntity entity);

    }
}
