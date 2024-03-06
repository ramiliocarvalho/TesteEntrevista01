using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebAppTesteEntrevista01.Helper;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=DB_TesteTecnico01;User Id=postgres;Password=Pass@1234; "));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

IServiceCollection serviceCollection = builder.Services.AddScoped<IMoto, WebAppTesteEntrevista01.Repository.Moto>();
serviceCollection = builder.Services.AddScoped<IUsuario, WebAppTesteEntrevista01.Repository.Usuario>();
serviceCollection = builder.Services.AddScoped<ILocacao, WebAppTesteEntrevista01.Repository.Locacao>();
serviceCollection = builder.Services.AddScoped<IPlano, WebAppTesteEntrevista01.Repository.Plano>();
serviceCollection = builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
