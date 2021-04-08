using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thinkbridgeAssignment.Model;

namespace thinkbridgeAssignment.Repository
{
   public interface IProduct : IDisposable
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductDetail(int? id);
        Task<IActionResult> PutProduct(int id,Product p);
        Task PostProducts(Product p);
        Task<int> DeleteProduct(int id);
    }
}
