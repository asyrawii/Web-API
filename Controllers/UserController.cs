using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using Web_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static List<User> usrNew = new List<User>();

        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            if (usrNew.Count == 0)
            {
                usrNew = JsonFileServices.LoadJsonFile<User>("UserList.json");

                if (usrNew == null)
                {
                    usrNew = new List<User>();
                }
            }

            return usrNew; //new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return usrNew.Find(x => x.UserID == id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            if (usrNew.Count == 0)
            {
                usrNew = JsonFileServices.LoadJsonFile<User>("UserList.json");

                if (usrNew == null)
                {
                    usrNew = new List<User>();
                }
            }

            usrNew.Add(value);
            JsonFileServices.SaveJsonFile<User>(usrNew, "UserList.json");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            User selectedUser = usrNew.Find(x => x.UserID == id);

            if (selectedUser != null)
            {
                if (value.NRIC != null)
                    selectedUser.NRIC = value.NRIC;

                if (value.DOB != null)
                    selectedUser.DOB = value.DOB;
            }

            JsonFileServices.SaveJsonFile<User>(usrNew, "UserList.json");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User selectedUser = usrNew.Find(x => x.UserID == id);

            if (selectedUser != null)
            {
                usrNew.Remove(selectedUser);
            }

            JsonFileServices.SaveJsonFile<User>(usrNew, "UserList.json");
        }
    }
}