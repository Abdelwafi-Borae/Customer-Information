using Base.Data;
using Base.Services.UnitOfWork;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("con");
builder.Services.AddDbContext<ApplicationDbContext>(option=>option.UseSqlServer(connection));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers().AddNewtonsoftJson();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//globale errorhandling
app.UseExceptionHandler(errors =>
{
    errors.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextfeature != null)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                statuscode = context.Response.StatusCode,
                message = "Internal Server Error"
            });

        }
       
    });


});
////coment
app.Run();
////coment