using Bookstore.Models.Repositories;
using Bookstore.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookstoreRepository<Author>,AuthorDbRepository>();
builder.Services.AddScoped<IBookstoreRepository<Book>, BookDbRepository>();
var connectionString = builder.Configuration.GetConnectionString("SqlCon");
builder.Services.AddDbContext<BookstoreDbContext>(x => x.UseSqlServer(connectionString));
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
/*app.UseMvc(route =>
{
    route.MapRoute("default", "{controller=book}/{action=index}/{id?}");
});*/


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
