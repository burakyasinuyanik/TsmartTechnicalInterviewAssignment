using Microsoft.EntityFrameworkCore;
using TsmartTechnicalInterviewAssignment.Api;
using TsmartTechnicalInterviewAssignment.Api.Extensions;
using TsmartTechnicalInterviewAssignment.Api.Features.Products;
using TsmartTechnicalInterviewAssignment.Repositories;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("de")));
builder.Services.AddCommonServiceExt(typeof(ProductAssembly));
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.ConfigureIdentity();
builder.Services.AddVersioningExt();


builder.Services.AddOpenApi();

var app = builder.Build();

app.AddProductGroupEndPointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

