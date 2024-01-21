using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using TahelefCourse.Core.Common;
using TahelefCourse.Infra.Common;

namespace TahelefCourse.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
    //Instance from DB  CorePro     InfraPro         
        public readonly IDbContext DbContext;
        public LoginRepository(IDbContext dbContext) { 
            this.DbContext = dbContext;
        }
        public Login  GenerateToken (Login login)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input); //User_NAME :the same name in tHe body of hte Package 
            p.Add("PASS" ,login.Password ,dbType: DbType.String, direction:ParameterDirection.Input);
            var res = DbContext.Connection.Query<Login>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault();
        }
    }
}
