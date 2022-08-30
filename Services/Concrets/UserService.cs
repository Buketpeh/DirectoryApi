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
        //To do: Repolar için ortak bir method yazılacak
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<CommunicationInfo> _communicationRepository;
        public UserService(IRepository<User> userRepository,IRepository<CommunicationInfo> communicationRepository)
        {
            _userRepository = userRepository;
            _communicationRepository = communicationRepository;
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

        public Result UpdateUser(AddOrUpdateUserBindingModel model)
        {
            var result = _userRepository.ReplaceOne(new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Company = model.Company

            },model._id.ToString());

            return result;
        }
        public Result DeleteUser(string id)
        {
            var result = _userRepository.DeleteById(id);

            return result;
        }
        public Result DetailUser(string id)
        {
            var result = _userRepository.GetById(id);

            return result;
        }

        public Result AddUserContact(string id, ContactInfoListBindingModel model)
        {
            var result = _userRepository.GetById(id);
            if (result == null)
                throw new Exception("Record not found!");
            foreach (var item in model.ContactInfo)
            {
                result.Entity.CommunicationInfo.Add(new CommunicationInfo
                {
                    _id = MongoDB.Bson.ObjectId.GenerateNewId(),
                    InfoType = item.InfoType,
                    Info = item.Info
                });
            }

            return result;
        }

        public Result DeleteUserContact(string id)
        {
            var result = _userRepository.DeleteById(id);

            return result;
        }
    }
}
