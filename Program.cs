using EmpoyeeAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("enableAll", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });

});
builder.Services.AddDbContext<EmployeeDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// Configure.Cors policy should be applied before UseAuthorization and UseEndpoints.
app.UseCors("enableAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
