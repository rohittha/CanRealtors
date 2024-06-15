using Microsoft.EntityFrameworkCore;
using Realtor.API;
using Realtor.API.Data;
using Realtor.API.Repository;
using Realtor.API.Services;
using Realtor.Application;
using Realtor.Infrastructure;
//using Realtor.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    var DbConnectionString = builder.Configuration.GetConnectionString("DbConnection");
    builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(DbConnectionString));
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddPresentationServices();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseMiddleware<ErrorHandlingMiddleware>(); // To use Error Handling custo middleware
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();

app.Run();
