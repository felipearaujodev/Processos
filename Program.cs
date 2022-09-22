using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Repository;
using Processos.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProcessoContext>(opt=>opt.UseInMemoryDatabase("processos"));
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
builder.Services.AddScoped<IHistoricoRepository, HistoricoRepository>();

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
