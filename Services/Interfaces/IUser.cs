using PhoneDirectoryApi.Core.Models;
using Shared.Model.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUser
    {
        Result AddUser(AddOrUpdateUserBindingModel model);
        Result UpdateUser(AddOrUpdateUserBindingModel model);
        Result DeleteUser(string id);
        Result DetailUser(string id);
        Result AddUserContact(string id, ContactInfoListBindingModel model);
        Result DeleteUserContact(string id);
        Result Users();
    }
}
