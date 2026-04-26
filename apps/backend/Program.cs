var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => new
{
    name = "argus-backend",
    version = Environment.GetEnvironmentVariable("APP_VERSION") ?? "dev",
    commit = Environment.GetEnvironmentVariable("GIT_COMMIT") ?? "unknown"
});

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));


app.Run();
