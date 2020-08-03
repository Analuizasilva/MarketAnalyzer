using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Dao<T>
    {
        private Context _context;

        public Dao()
        {
            _context = new Context();
        }

        #region Create
        public void Create()
        {
            
        }
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
