using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TsmartTechnicalInterviewAssignment.Api;
using TsmartTechnicalInterviewAssignment.Api.Extensions;
using TsmartTechnicalInterviewAssignment.Api.Features.Products;
using TsmartTechnicalInterviewAssignment.Api.Features.Users;
using TsmartTechnicalInterviewAssignment.Repositories;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppIdentityDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
    options.ConfigureWarnings(o=>o.Ignore(RelationalEventId.PendingModelChangesWarning));
    });
builder.Services.AddCommonServiceExt(typeof(ProductAssembly));
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.AddVersioningExt();


builder.Services.AddOpenApi();

var app = builder.Build();

 app.AddSeedDataExt();

app.AddProductGroupEndPointExt(app.AddVersionSetExt());
app.AddUserGroupEndPointExt(app.AddVersionSetExt());
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseAuthorization();
app.UseHttpsRedirection();

app.Run();

