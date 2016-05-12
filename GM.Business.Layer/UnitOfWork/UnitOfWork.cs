using System;
using GM.Data.Model;
using GM.Business.Layer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace GM.Business.Layer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        private GlobaMartEntities context = new GlobaMartEntities();
        private GenericRepository<ProductType> productTypeRepository;
        private GenericRepository<Product> productRepository;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    context.Dispose();
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save() { context.SaveChanges(); }

        #region GlobaMart Repositories
        
        public GenericRepository<ProductType> ProductTypeRepository
        {
            get
            {
                if (this.productTypeRepository == null)
                    this.productTypeRepository = new GenericRepository<ProductType>(context);

                return productTypeRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new GenericRepository<Product>(context);

                return productRepository;
            }
        }

        #endregion
    }
}
