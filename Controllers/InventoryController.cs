using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using Web_API.Services;

namespace Web_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        static List<Inventory> newInventory = new List<Inventory>();

        public object Inventories { get; private set; }

        // Web_API.Models.User usrNew = new Models.User();
        // GET: api/<UserController>
        [HttpGet]

        public IEnumerable<Inventory> Get()
        {
            if (newInventory.Count == 0)
            {
                newInventory = JsonFileServices.LoadJsonFile<Inventory>("InventoryList.json");

                if (newInventory == null)
                {
                    newInventory = new List<Inventory>();
                }
            }

            return newInventory; //new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("profit")]

        public string GetProfit()
        {
            if (newInventory.Count == 0)
            {
                newInventory = JsonFileServices.LoadJsonFile<Inventory>("InventoryList.json");

                if (newInventory == null)
                {
                    newInventory = new List<Inventory>();
                }
            }

            return InventoryServices.ProfitCalculator(newInventory);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Inventory Get(int id)
        {
            return newInventory.Find(x => x.SerialNumber == id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] Inventory value)
        {
            if (newInventory.Count == 0)
            {
                newInventory = JsonFileServices.LoadJsonFile<Inventory>("InventoryList.json");

                if (newInventory == null)
                {
                    newInventory = new List<Inventory>();
                }
            }

            newInventory.Add(value);
            JsonFileServices.SaveJsonFile<Inventory>(newInventory, "InventoryList.json");

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Inventory value)
        {
            Inventory selectedInventory = newInventory.Find(x => x.SerialNumber == id);

            if (selectedInventory != null)
            {
                if (value.BuyingPrice != null)
                    selectedInventory.BuyingPrice = value.BuyingPrice;

                if (value.SellingPrice != null)
                    selectedInventory.SellingPrice = value.SellingPrice;
            }

            JsonFileServices.SaveJsonFile<Inventory>(newInventory, "InventoryList.json");
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Inventory selectedInventory = newInventory.Find(x => x.SerialNumber == id);

            if (selectedInventory != null)
            {
                newInventory.Remove(selectedInventory);
            }

            JsonFileServices.SaveJsonFile<Inventory>(newInventory, "InventoryList.json");
        }
    }
}
