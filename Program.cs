using Microsoft.EntityFrameworkCore;
using Chapter18.Models; 
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
// To add a migration your dbcontext must be creatable at the point the tool is run.

//You need either a parameterless constructor or a design time factory. 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BookConnection")));
  

var app = builder.Build();

app.UseMiddleware<Chapter18.TestMiddleware>();
const string BASEURL = "api/books";
app.MapGet($"{BASEURL}/{{id}}", async (HttpContext context, DataContext data) => {
    string? id = context.Request.RouteValues["id"] as string;
    if (id != null) {
        Book? p = data.Books.Find(long.Parse(id));
        if (p == null) {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        } else {
            context.Response.ContentType = "application/json";
            await context.Response
                .WriteAsync(JsonSerializer.Serialize<Book>(p));
        }
    }
});
app.MapGet(BASEURL, async (HttpContext context, DataContext data) => {
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer
        .Serialize<IEnumerable<Book>>(data.Books));
});
app.MapPost(BASEURL, async (HttpContext context, DataContext data) => {
    Book? p = await
        JsonSerializer.DeserializeAsync<Book>(context.Request.Body);
    if (p != null) {
        await data.AddAsync(p);
       await data.SaveChangesAsync();
        context.Response.StatusCode = StatusCodes.Status200OK;
    }
});



app.MapGet("/", () => "Hello aspnetcore World!");

var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

  


app.Run();
