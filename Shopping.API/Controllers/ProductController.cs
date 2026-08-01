using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger, ProductContext productContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productContext.Products.Find(p=> true).ToListAsync();
        }
    }
}
