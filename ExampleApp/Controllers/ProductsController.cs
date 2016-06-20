using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExampleApp.Models;

namespace ExampleApp.Controllers
{
    public class ProductsController : ApiController
    {
        IRepository repo;

        public ProductsController(IRepository repoImpl)
        {
            repo = repoImpl;
        }

        public IEnumerable<Product> GetAll()
        {
            return repo.Products;
        }
    }
}
