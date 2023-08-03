using AksamWeb.DataOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AksamEf>(p => {
    p.UseSqlServer("Data Source=.\\;Initial Catalog=BlogDB;User ID=efuser;Password=123");
});

builder.Services.AddDefaultIdentity<IdentityUser>(opt => {
})
    .AddEntityFrameworkStores<AksamEf>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();
app.MapControllerRoute("default", "{controller=Main}/{action=Default}/{id?}");
app.MapAreaControllerRoute("areas", "identity", "{controller=Main}/{action=Default}/{id?}");


app.Run();
