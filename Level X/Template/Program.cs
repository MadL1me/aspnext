using System.Text;
#if(swagger)
using Microsoft.OpenApi.Models;
#endif
#if (UsePostgreSql || identity)
using Microsoft.EntityFrameworkCore;
using AspAwesomeTemplate.Data;
#endif
#if (identity)
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
#endif
#if (UseJwtAuth)
using Microsoft.AspNetCore.Authentication.JwtBearer;
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#if(swagger)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspAwesomeTemplate API", Version = "v1" });

    #if (UseJwtAuth)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        In = ParameterLocation.Header, 
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { 
            new OpenApiSecurityScheme 
            { 
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" 
                } 
            },
            new string[] { } 
        } 
    });
    #endif
});
#endif

#if (UsePostgreSql || identity)
builder.Services.AddDbContext<AspAwesomeTemplateDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));  
#endif

#if (identity)
builder.Services.AddIdentity<User, IdentityRole>()  
    .AddEntityFrameworkStores<AchieveBoardDbContext>()  
    .AddDefaultTokenProviders();  
#endif

#if (UseJwtAuth)
builder.Services.AddAuthentication(options =>  
    {  
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;  
    })  
  
    // Adding Jwt Bearer  
    .AddJwtBearer(options =>  
    {  
        options.SaveToken = true;  
        options.RequireHttpsMetadata = false;  
        options.TokenValidationParameters = new TokenValidationParameters()  
        {  
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))  
        };

        options.Validate();
    });  
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
#if(swagger)
    app.UseSwagger();
    app.UseSwaggerUI();
#endif
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();