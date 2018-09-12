using MyStore.Domain.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(string email, string username, string password);
    }
}
