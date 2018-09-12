using MyStore.Domain.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> GetByUserName(string userName)
        {
            return x => x.UserName == userName;
        }

        public static Expression<Func<User, bool>> GetByAuthorizationCode(string authorizationCode)
        {
            return x => x.AuthorizationCode == authorizationCode;
        }
    }
}
