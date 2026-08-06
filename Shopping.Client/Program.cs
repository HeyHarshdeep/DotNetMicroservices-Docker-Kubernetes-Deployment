var builder = WebApplication.CreateBuilder(args);

// Use builder.Configuration instead of Configuration
builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    var shoppingApiUrl = builder.Configuration["ShoppingAPIUrl"]
        ?? throw new InvalidOperationException("ShoppingAPIUrl configuration is missing.");

    client.BaseAddress = new Uri(shoppingApiUrl);
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
