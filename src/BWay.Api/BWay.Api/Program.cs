using AutoMapper;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Repository.Repositories;
using BWay.Service.Interfaces;
using BWay.Service.Mappings;
using BWay.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlantaoRepository, PlantaoRepository>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();

builder.Services.AddScoped<IPlantaoService, PlantaoService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new PlantoesProfile());
    mc.AddProfile(new ProjetoProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
