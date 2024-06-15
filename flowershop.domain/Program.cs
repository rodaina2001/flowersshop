using flowershop.domain.flowershop; 
using flowershop.domain.flowershop;

var builder = WebApplication.CreateBuilder(args);
object value = builder.Services.AddDbContextFactory<flowercontext>(Options =>
Options.UseSqlServer(connectionString: "Server=.\\sqlexpress;Database=flowersDb;Trusted_Connection=True;"));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<APP>()
    .AddInteractiveServerRenderMode();

app.Run();
