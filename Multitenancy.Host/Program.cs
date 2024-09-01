using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Multitenancy;
using Multitenancy.Application;
using Multitenancy.CustomUser;
using Multitenancy.Database.Tenant;
using Multitenancy.Database.User;
using Multitenancy.Endpoints;
using Multitenancy.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityDatabase(builder.Configuration)
    .AddIdentityApiEndpoints<User>()
    .AddApiEndpoints();

builder.Services.AddMultitenancyDatabase();

builder.Services.AddCustomUserProperties();

builder.Services.AddApplicationServices();

builder.Services.AddScoped<MultitenancyMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseMigration();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<MultitenancyMiddleware>();

var apiGroup = app.MapGroup("/api");

apiGroup.MapOrganizationEndpoints()
.MapTenantEndpoints();

app.MapIdentityApi<User>();
app.Run();
