using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public abstract class Dao<T>
    {
        private Context _context;

        public Dao()
        {
            _context = new Context();
        }


        #region Create
        //public void Create(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //}
        #endregion

        #region Read
        public void Read()
        {

        }
        #endregion

        #region Update
        public void Update()
        {

        }
        #endregion

        #region Delete
        public void Delete()
        {

        }
        #endregion



    }
}
