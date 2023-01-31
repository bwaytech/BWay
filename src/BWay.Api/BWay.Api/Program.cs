using AutoMapper;
using BWay.Infra.Data;
using BWay.Infra.Interfaces;
using BWay.Infra.Utils;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Repository.Repositories;
//using BWay.Repository.Repositories;
using BWay.Service.Interfaces;
using BWay.Service.Mappings;
using BWay.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
//builder.Services.AddScoped<IOperacaoCorretorRepository, OperacaoCorretorRepository>();
//builder.Services.AddScoped<IOperacaoRepository, OperacaoRepository>();
//builder.Services.AddScoped<IPlantaoRepository, PlantaoRepository>();
//builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
//builder.Services.AddScoped<IRoletaRepository, RoletaRepository>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
//builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();
//builder.Services.AddScoped<ICorretorService, CorretorService>();
//builder.Services.AddScoped<IOperacaoCorretorService, OperacaoCorretorService>();
//builder.Services.AddScoped<IOperacaoService, OperacaoService>();
//builder.Services.AddScoped<IPlantaoService, PlantaoService>();
//builder.Services.AddScoped<IProjetoService, ProjetoService>();
//builder.Services.AddScoped<IRoletaService, RoletaService>();
//builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<DbSession>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();


builder.Services.AddScoped<IUtil, Util>();

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
