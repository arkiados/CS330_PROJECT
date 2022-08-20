using CS330_PROJECT;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // I removed swagger. It was broken anyways.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
