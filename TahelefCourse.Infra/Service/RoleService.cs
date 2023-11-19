using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using Tahelef.Core.Service;

namespace TahelefCourse.Infra.Service
{
    public  class RoleService :IRoleService 
    {
        private readonly IRoleRepository _RoleRepository;
        public RoleService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public void CreateRole(Role Role)
        {
            _RoleRepository.CreateRole(Role);
        }

        public void DeleteRole(int id)
        {
            _RoleRepository.DeleteRole(id);
        }

        public List<Role> GetAllRole()
        {
            return _RoleRepository.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return _RoleRepository.GetByRoleId(id);
        }

        public void UpdateRole(Role Role)
        {
            _RoleRepository.UpdateRole(Role);
        }
    }
}
