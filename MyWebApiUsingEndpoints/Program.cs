using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyWebApiUsingEndpoints.DataAccess;
using MyWebApiUsingEndpoints.DomainModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseSqlite("Data Source=database.sqlite"));

builder.Services.AddControllers(options => options.UseNamespaceRouteToken()); // See Notes\ProgramError.txt

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApiUsingEndpoints", Version = "v1" });
  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MyWebApiUsingEndpoints.xml"));
	c.UseApiEndpoints();
});

builder.Services.AddAutoMapper(typeof(Program));  // Startup

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseSwagger(); 
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApiUsingEndpoints V1"));

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
});

app.MapRazorPages();
app.Run();
