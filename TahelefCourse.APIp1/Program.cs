
using Tahelef.Core.Repository;
using Tahelef.Core.Service;
using TahelefCourse.Core.Common;
using TahelefCourse.Infra.Common;
using TahelefCourse.Infra.Repository;
using TahelefCourse.Infra.Service;
// watchout not using .Entityframework.core 
namespace TahelefCourse.APIp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Dependancy Injection 
            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            // Services 
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IStudentCourseService, StudentCourseService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}