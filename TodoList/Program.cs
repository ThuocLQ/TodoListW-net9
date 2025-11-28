var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<ITodoItemRepository, InmemoryTodoItemRepository>();
//builder.Services.AddTransient<TodoListManager>();

// PostgreSQL connection string
var connStr = builder.Configuration.GetConnectionString("Postgres");

// EF DbContext
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseNpgsql(connStr));

// DI repository
builder.Services.AddScoped<ITodoItemRepository, EfTodoItemRepository>();
builder.Services.AddScoped<TodoListManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();