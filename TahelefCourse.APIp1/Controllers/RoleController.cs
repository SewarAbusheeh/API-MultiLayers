using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Tahelef.Core.Models;
using Tahelef.Core.Service;
using TahelefCourse.Core.Common;

namespace TahelefCourse.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService RoleService;
        public RoleController(IRoleService RoleService)
        {
            this.RoleService = RoleService;
        }
        [HttpGet]
        [Route("GetAllRole")]
        public List<Role> GetAllRole()
        {
            return RoleService.GetAllRole();
        }
        [HttpGet]
        [Route("GetByRoleId/{id}")]
        public Role GetByRoleId(int id)
        {
            return RoleService.GetRoleById(id);
        }
        [HttpPost]
        [Route("CreateRole")]
        public void CreateRole(Role Role)
        {
            RoleService.CreateRole(Role);
        }
        [HttpPut]
        [Route("UpdateRole")]
        public void UpdateRole(Role Role)
        {
            RoleService.UpdateRole(Role);
        }
        [HttpPost]
        [Route("DeleteRole")]
        public void DeleteRole(int id)
        {
            RoleService.DeleteRole(id);
        }
    }
}
