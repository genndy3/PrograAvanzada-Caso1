using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Configuraci�n de la conexi�n a la base de datos usando el contexto
builder.Services.AddDbContext<SnakeGameContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SnakeGameDB")));


builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configuraci�n del middleware de la aplicaci�n.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();