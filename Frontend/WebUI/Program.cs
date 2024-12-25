using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using WebUI.Dtos.RoomDto;
using WebUI.Dtos.ServiceDto;
using WebUI.ValidationRules.Room;
using WebUI.ValidationRules.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IValidator<CreateRoomDto>, CreateRoomValidator>();
builder.Services.AddTransient<IValidator<UpdateRoomDto>, UpdateRoomValidator>();
builder.Services.AddTransient<IValidator<CreateServiceDto>, CreateServiceValidator>();
builder.Services.AddTransient<IValidator<UpdateServiceDto>, UpdateServiceValidator>();

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/{0}");
app.UseStaticFiles();
app.UseRouting(); 
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
