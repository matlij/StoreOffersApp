using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOffer.API.Models;

namespace StoreOffer.API.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly TempAppDbContext dbContext;

        public StoreController(TempAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        //[Route("[action]")]
        public IActionResult Get()
        {
            try
            {
                var stores = dbContext.Stores;
                return Ok(stores);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}