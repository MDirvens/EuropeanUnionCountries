using EuropeanUnionCountries.Core.Dto;
using Microsoft.OpenApi.Models;
using EuropeanUnionCountries.Data;
using EuropeanUnionCountries.Core.Services;
using EuropeanUnionCountries.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EuropeanCountryData", Version = "v1" });
});

builder.Services.AddDbContext<CountriesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("countries"));
});

builder.Services.AddTransient<IAddDataService, AddDataService>();
builder.Services.AddTransient<IGetDataService, GetDataService>();
builder.Services.AddTransient<ICountriesDbContext, CountriesDbContext>();
builder.Services.AddTransient<IAddDataService, AddDataService>();
builder.Services.AddTransient<IEntityService<CountryDto>, EntityService<CountryDto>>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IMapperService, MapperService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
