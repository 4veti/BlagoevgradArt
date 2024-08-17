using BlagoevgradArt.Extensions;
using BlagoevgradArt.ModelBinders;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity();

builder.Services.AddControllersWithViews(options =>
{
    //options.ModelBinderProviders.Insert(1, new ManageUserRolesModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Painting Details",
        pattern: "Painting/Details/{id}/{information}",
        defaults: new { Controller = "Painting", Action = "Details" });

    endpoints.MapControllerRoute(
        name: "Painting Edit",
        pattern: "Painting/Edit/{id}/{information}",
        defaults: new { Controller = "Painting", Action = "Edit" });

    endpoints.MapControllerRoute(
        name: "Painting Delete",
        pattern: "Painting/Delete/{id}/{information}",
        defaults: new { Controller = "Painting", Action = "Delete" });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

await app.CreateAndAssignAdminRoleAsync();

await app.RunAsync();
