using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentList.DataBase.Context;
using StudentList.Interfaces;
using StudentList.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StudentDB")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API Managing Student List",
    });
});

void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();

    services.AddScoped<IStudentService, StudentService>();
}

var app = builder.Build();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
