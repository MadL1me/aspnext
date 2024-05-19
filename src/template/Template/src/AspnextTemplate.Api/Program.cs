using System.Text;
#if(EnableSwaggerSupport)
using Microsoft.OpenApi.Models;
#endif
#if (UsePostgreSql)
using Microsoft.EntityFrameworkCore;
using AspnextTemplate.Data;
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#if(EnableSwaggerSupport)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspnextTemplate API", Version = "v1" });
});
#endif

#if (UsePostgreSql)
builder.Services.AddDbContext<AspnextTemplateDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));  
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
#if(EnableSwaggerSupport)
    app.UseSwagger();
    app.UseSwaggerUI();
#endif
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();