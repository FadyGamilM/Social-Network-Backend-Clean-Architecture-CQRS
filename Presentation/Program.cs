using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//!=> inject the db context with postgres database server
//*=> connect to postgres through the AppDbContext
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("conn")
    )
);
//!=> utilize the api versioning nuget package
builder.Services.AddApiVersioning(
   options => 
   {
      // provide our client by the different api versions that we have
      options.ReportApiVersions = true;
      // allow the api to automatically provide a default version
      options.AssumeDefaultVersionWhenUnspecified = true;
      // the default version
      options.DefaultApiVersion= ApiVersion.Default;
      // what approach of versioning we will go with, which will be in the url of the controllers "api/{v1}/resource
      options.ApiVersionReader = new UrlSegmentApiVersionReader();
   }
);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


