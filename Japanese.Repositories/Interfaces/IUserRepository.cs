using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Repositories.Interfaces
{
    public interface IUserRepository : IDynamoDBService<UserModel>
    {
        Task<UserModel> GetUserByEmailAsync(string email);

    }
}
