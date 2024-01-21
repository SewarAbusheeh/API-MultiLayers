using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using TahelefCourse.Core.Common;

namespace TahelefCourse.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext dBContext;
        public RoleRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("roleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
             dBContext.Connection.ExecuteAsync("Role_Package.CreateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("roleID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
             dBContext.Connection.ExecuteAsync("Role_Package.DeleteRole", p, commandType: CommandType.StoredProcedure);
        }

        public List<Role> GetAllRoles()
        {
            IEnumerable<Role> result = dBContext.Connection.Query<Role>("Role_Package.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetByRoleId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_roleID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var  result = dBContext.Connection.Query<Role>("Role_Package.GetRoleById", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("roleID", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("roleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            dBContext.Connection.ExecuteAsync("Role_Package.UpdateRole", p, commandType: CommandType.StoredProcedure);
        }


    }
}
