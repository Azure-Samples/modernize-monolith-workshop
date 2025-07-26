using System;
using System.Collections.Generic;
using System.Linq;
using eShopLite.StoreCore.Data;
using eShopLite.StoreFx.Models;

namespace eShopLite.StoreCore.Services
{
    public interface IStoreService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<StoreInfo> GetStores();
    }

    public class StoreService : IStoreService
    {
        private readonly IStoreDbContext _context;

        public StoreService(IStoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<StoreInfo> GetStores()
        {
            return _context.Stores.ToList();
        }
    }
}