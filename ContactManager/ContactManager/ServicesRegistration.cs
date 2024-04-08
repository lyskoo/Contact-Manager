using AutoMapper;
using Business.Services;
using Business.Services.Interfaces;
using Data.Data;
using Data.Repositories;
using Data.Repositories.Iterfaces;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ContactManager;

public static class ServicesRegistration
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddScoped<IContactRepository, ContactRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IContactService, ContactService>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(connectionString));

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new Mappings.AutoMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }
}
