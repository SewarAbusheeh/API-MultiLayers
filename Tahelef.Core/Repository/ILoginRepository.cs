using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Repository
{
    public interface ILoginRepository
    {
        Login GenerateToken(Login login);
    }
}
