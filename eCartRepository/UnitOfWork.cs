using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eCartContracts.IRepository;
using eCartDAL.DBContext;

namespace eCartRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task SaveAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRep;
        private ICategoryRepository _categoryRepo;
        private eCartDBContext context;

        public UnitOfWork(eCartDBContext context)
        {
            this.context = context;
        }

        // Repositories are exposed via 
        // getter properties  to the calling components

        public IProductRepository ProductRepository
        {
            get
            {
                return new ProductRepository(context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return new CategoryRepository(context);
            }
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
