using KmpShopBackend.Src.Core.Extenstions;
using KmpShopBackend.Customer.Core.Extenstions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddKmpShopApiServices(builder.Configuration)
    .AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();