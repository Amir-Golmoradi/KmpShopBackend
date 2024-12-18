using KmpShopBackend.Src.Core.Extenstions;
using KmpShopBackend.Customer.Core.Extenstions;
using Microsoft.EntityFrameworkCore;
using KmpShopBackend.Src.Customer.Domain.Repository;
using KmpShopBackend.Src.User.Infrastructure.Adapter.Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddKmpShopApiServices(builder.Configuration)
    .AddControllers();
// builder.Services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();