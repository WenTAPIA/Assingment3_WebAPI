using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieCharacterAPI.Models;
using MovieCharacterAPI.Profiles;
using MovieCharacterAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(FranchiseProfile));
builder.Services.AddAutoMapper(typeof(CharacterProfile));
builder.Services.AddAutoMapper(typeof(MovieProfile));
//This line is to setup the connection to the server
builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IMovieServices), typeof(MovieServices));
builder.Services.AddScoped(typeof(IFranchiseServices), typeof(FranchiseServices));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MovieCharacterAPI",
        Version = "v1",
        Description = "Backend:Assignment3_Noroff",
        Contact = new OpenApiContact
        {
            Name = "Wendy Tapia",
            Email = "wt@triark.no",
            Url = new Uri("https://linkedin.com/in/wendy-tapia-arispe-8738978a")
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieCharacterAPI v1"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

