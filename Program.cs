using Customer_Information.Data;
using Customer_Information.Services.UnitOfWork;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

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
//builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});


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
////app.UseExceptionHandler(errors =>
//{
//    errors.Run(async context =>
//    {
//        context.Response.StatusCode = 500;
//        context.Response.ContentType = "application/json";
//        var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
//        if (contextfeature != null)
//        {
//            await context.Response.WriteAsJsonAsync(new
//            {
//                statuscode = context.Response.StatusCode,
//                message = "Internal Server Error"
//            });

//        }
       
//    });


//});
////coment
app.Run();
////coment