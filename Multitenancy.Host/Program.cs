using Microsoft.AspNetCore.Identity;
using Multitenancy;
using Multitenancy.Database.Tenant;
using Multitenancy.Database.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddIdentityDatabase(builder.Configuration)
    .AddIdentityApiEndpoints<User>()
    .AddApiEndpoints()
    .AddDefaultTokenProviders();

builder.Services.AddMultitenancyDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseMigration();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.Run();
