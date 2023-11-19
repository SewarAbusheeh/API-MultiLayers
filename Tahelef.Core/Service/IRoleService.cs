using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Service
{
    public interface IRoleService
    {
        List<Role> GetAllRole();
        void CreateRole(Role Role);
        void UpdateRole(Role Role);
        void DeleteRole(int id);
        Role GetRoleById(int id);
    }
}
