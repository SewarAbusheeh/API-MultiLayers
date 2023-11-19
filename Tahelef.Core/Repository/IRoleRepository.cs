using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Repository
{
   public interface  IRoleRepository
    {
        List<Role> GetAllRoles();
        Role GetByRoleId(int id);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}
