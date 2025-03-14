using DataAccess;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions;
using Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));


builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddMappings();
builder.Services.AddValidators();

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwaggerWithJwtAuth();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
