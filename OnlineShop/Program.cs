using App.Domain.Core.DataAccess;
using App.Infrastructures.Data.Repositories.AutoMapper;
using App.Infrastructures.Data.Repositories.Comments;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.AddJsonFile("appsettings.Development.json", optional: false)
.Build();

#region config DI
builder.Services.AddScoped<ICommentRepository, CommentsRepository>();


#endregion config DI
#region config identity
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDBContext>();
#endregion config identity

//builder.Services.AddScoped<ICommentRepository, CommentsRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapper_Infra));

#region config dbContext
var connectionString = config.GetSection("ConnectionStrings:DefaultConnection").Value;
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion config dbContext


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
