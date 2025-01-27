using Microsoft.EntityFrameworkCore;
using BarrelsAccounting.Accounting;
using BarrelsAccounting.Accounting.Util;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Postgres");


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddControllers();

builder.AddKeycloak();
builder.Services.AddDataBase(connectionString);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(
    x => x.AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(_ => true)
          .AllowCredentials());

app.Run();
