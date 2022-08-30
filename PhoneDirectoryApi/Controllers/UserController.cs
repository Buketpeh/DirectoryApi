using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectoryApi.Core.Models;
using PhoneDirectoryApi.Core.Repository.Abstract;
using Services.Interfaces;
using Shared.Model.BindingModel;

namespace PhoneDirectoryApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUser _user;

        public UserController(IRepository<User> userRepository, IUser user)
        {
            _userRepository = userRepository;
            _user = user;

        }
        [Route("api/[controller]")]
        [HttpPost]
        public Result Create(AddOrUpdateUserBindingModel model) => _user.AddUser(model);

        [Route("api/[controller]")]
        [HttpPut]
        public Result Update(AddOrUpdateUserBindingModel model) => _user.UpdateUser(model);

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public Result Delete(string id) => _user.DeleteUser(id);

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public Result Detail(string id) => _user.DetailUser(id);

        [Route("api/[controller]/{id}/ContactInfo")]
        [HttpPost]
        public Result CreateContactInfo(string id,ContactInfoListBindingModel model) =>  _user.AddUserContact(id,model) ;

        [Route("api/[controller]/ContactInfo/{id}")]
        [HttpDelete]
        public Result DeleteContactInfo(string id) => _user.DeleteUserContact(id);

        [Route("api/[controller]")]
        [HttpGet]
        public Result UsersList() => _user.Users();

    }
}
