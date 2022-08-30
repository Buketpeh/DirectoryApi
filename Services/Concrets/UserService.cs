using Data.Entities;
using PhoneDirectoryApi.Core.Models;
using PhoneDirectoryApi.Core.Repository.Abstract;
using Services.Interfaces;
using Shared.Model.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrets
{
    public class UserService: IUser
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public Result AddUser(AddOrUpdateUserBindingModel model)
        {
            var result = _userRepository.InsertOne(new User
            {
                _id = MongoDB.Bson.ObjectId.GenerateNewId(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Company = model.Company

            });

            return result;
        }

    }
}
