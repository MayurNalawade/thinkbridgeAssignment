using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thinkbridgeAssignment.Model;

namespace thinkbridgeAssignment.Repository
{
    public class ProductRepository :IProduct
    {
        private DataBaseConnectionContext _context;

        public ProductRepository(DataBaseConnectionContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProducts()
        {
            if(_context != null)
            {
                return await _context.products.ToListAsync();
            }
            return null;
        }

        public async Task<Product> GetProductDetail(int? id)
        {
            if(_context != null)
            {
                return await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);
            }
            return null;
        }


        public async Task<IActionResult> PutProduct(int id,Product post)
        {
            if (_context != null)
            {
                _context.Entry(id).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!ProductsExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return null;
        }

        private bool ProductsExists(int id)
        {
            return _context.products.Any(e => e.ProductId == id);
        }

        public async Task PostProducts(Product product)
        {

            if (_context != null)
            {
                //update that product
                _context.products.Update(product);

                //Commit the transaction
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<int> DeleteProduct(int id)
        {
            int result = 0;

            if (_context != null)
            {
                //Find the product for specific product id
                var post = await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);

                if (post != null)
                {
                    //Delete that product
                    _context.products.Remove(post);

                    //Commit the transaction
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
