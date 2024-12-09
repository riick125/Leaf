using Leaf.Application.Interfaces;
using Leaf.Application.Mapper;
using Leaf.Application.Services;
using Leaf.Domain.Interfaces;
using Leaf.Infrastructure.Context;
using Leaf.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IEventoUsuarioRepository, EventoUsuarioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEventoServiceApp, EventoServiceApp>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LeafDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Evento}/{action=Incluir}/{id?}");

app.Run();
