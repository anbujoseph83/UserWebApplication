using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using UserWebApplication.Models;
using UserWebApplication.Repository;
using Formatting = Newtonsoft.Json.Formatting;

namespace UserWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class UserManagementController : ControllerBase
    {
         

        private readonly IUserRepository<User> _userRepository;

        public UserManagementController(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
             

        }
        [HttpGet("[action]")]
        [Route("api/UserManagement/UserList")]
        public Object UserList()
        {
            var data = _userRepository.GetAll();
           
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [HttpPost("[action]")]
        [Route("api/UserManagement/CreateUser")]
        public async Task<Object> CreateUser([FromBody] User user)
        {
            try
            {
                await _userRepository.Create(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpGet("[action]")]
        [Route("api/UserManagement/GetUser")]
        public Object GetUser(int userid)
            {
                var data = _userRepository.GetById(userid);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }

        [HttpPost("[action]")]
        [Route("api/UserManagement/DeleteUser")]
        public bool DeleteUser(int userid)
        {
            try
            {
                 var data = _userRepository.GetById(userid);
                _userRepository.Delete(data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Person  
        [HttpPost("[action]")]
        [Route("api/UserManagement/UpdateUser")]
        public bool UpdateUser(User Object)
        {
            try
            { 
                _userRepository.Update(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
    }
 
