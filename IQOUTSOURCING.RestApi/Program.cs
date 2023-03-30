using IQOUTSOURCING.PersistenceSQLServer.Extensions;
using IQOUTSOURCING.Mappers.Extensions;
using IQOUTSOURCING.BusinessLogic.Extensions;
using IQOUTSOURCING.RestApi.Middleware;
using IQOUTSOURCING.RestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    o.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddBusinessExtensionServices();
builder.Services.AddMappingServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddJWT(builder.Configuration);

builder.Services.AddSwaggerGen();


builder.Services.AddCors(op =>
{
    op.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddMigrationServices();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
