using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_health.Areas.Identity.Data;
using E_health.Controllers.FamilyPlanning;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
builder.Services.AddScoped<FamilyPlanningMethodsController>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var roles = new[] { "Admin", "Doctor", "Nurse", "Patient" };
//    foreach (var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//        {
//            await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}

////admin added
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

//    string email = "admin@admin.com";
//    string password = "Admin@123";

//    if (await userManager.FindByEmailAsync(email) == null)
//    {
//        var user = new ApplicationUser();
//        user.Email = email;
//        user.UserName = email;
//        user.FirstName = email;
//        user.LastName = email;

//        await userManager.CreateAsync(user, password);

//        await userManager.AddToRoleAsync(user, "Admin");

//    }

//}


app.Run();
