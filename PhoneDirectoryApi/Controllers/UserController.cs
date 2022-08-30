using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectoryApi.Core.Repository.Abstract;

namespace PhoneDirectoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpPost(Name = "")]
        public IActionResult Create()
        {
            var result = _userRepository.InsertOne(new User
            {
                FirstName = "Test1",
                LastName = "TestLastName",
                Company = "TestCompany"
                
            });

        
            return Ok(result);
        }
    }
}
