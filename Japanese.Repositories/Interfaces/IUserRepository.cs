using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Repositories.Interfaces
{
    public interface IUserRepository : IAppRepository<UserModel>
    {
        Task<UserModel> GetUserByEmailAsync(string email);

    }
}
