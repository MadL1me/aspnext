using AspnextTemplate.Api.Extensions;
using AspnextTemplate.Infrastructure.Observability;
#if (AddZitadelAuth)
using AspnextTemplate.Infrastructure.Zitadel;
#endif
#if (UsePostgreSql)
using Microsoft.EntityFrameworkCore;
using AspnextTemplate.Data;
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add custom swagger extension method
builder.Services.AddSwaggerSetup();
#if (AddZitadelAuth)

// Add custom zitadel authentication
builder.Services.AddZitadelAuthentication(builder.Configuration);
#endif
#if (AddObservability)

// Add custom observability
builder.Services.AddObservability(new ObservabilityOptions(
    "your_env",
    "AspnextTemplate",
    "AspnextTemplate"));
#endif
#if (UsePostgreSql)

builder.Services.AddDbContext<AspnextTemplateDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
