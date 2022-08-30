using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectoryApi.Core.Models;
using PhoneDirectoryApi.Core.Repository.Abstract;
using Services.Interfaces;
using Shared.Model.BindingModel;

namespace PhoneDirectoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUser _user;

        public UserController(IRepository<User> userRepository, IUser user)
        {
            _userRepository = userRepository;
            _user = user;

        }

        [HttpPost(Name = "")]
        public Result Create(AddOrUpdateUserBindingModel model) => _user.AddUser(model);

        [HttpPut(Name = "")]
        public Result Update(AddOrUpdateUserBindingModel model) => _user.UpdateUser(model);

        [HttpDelete(Name = "")]
        public Result Delete(string id) => _user.DeleteUser(id);


    }
}
