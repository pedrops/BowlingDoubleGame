using BowlingGame.BL.Interfaces;
using BowlingGame.BL.Services;
using BowlingGame.DA;
using BowlingGame.DA.Interfaces;
using BowlingGame.DA.MongoDB.Interfaces;
using BowlingGame.DA.MongoDB.Repository;
using BowlingGame.DA.MongoDB.UoW;
using BowlingGame.DA.Repository;
using BowlingGame.DA.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace BowlingGame
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            SystemInfo systemInfo = new SystemInfo();
            systemInfo.FillSettings();
            services.AddSingleton<ISystemInfo>(systemInfo);

            // IoC logic applied
            // Deciding persintecy
            // Needs to be configured at json appsettings file

            if (systemInfo.Persistence == "SQL")
            {
                //Initialize SQL dto

                var optionsBuilder = new DbContextOptionsBuilder<BowlingGameDBContext>();
                optionsBuilder.UseSqlServer(systemInfo.ConnectionString);
                services.AddSingleton(optionsBuilder.Options);
                services.AddDbContext<BowlingGameDBContext>();
                services.AddSingleton<IBowlingCacheProvider, BowlingCacheProvider>();
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                services.AddSingleton<IBowlingCache, BowlingCache>();
                services.AddTransient<IGameRepository, GameRepository>();
                services.AddTransient<IGameSetupRepository, GameSetupRepository>();
                services.AddTransient<IPlayerRepository, PlayerRepository>();
            }
            else if (systemInfo.Persistence == "Mongo")
            {
                //Initialize Mongo Dependencies
                services.AddTransient<IMongoDbRepository, MongoDbRepository>();
                services.AddSingleton<IBowlingCacheProvider, BowlingCacheProvider>();
                services.AddTransient<IUnitOfWork, UnitOfWorkMongo>();
                services.AddSingleton<IBowlingCache, BowlingCache>();
                services.AddTransient<IGameRepository, GameMongoRepository>();
                services.AddTransient<IGameSetupRepository, GameSetupMongoRepository>();
                services.AddTransient<IPlayerRepository, PlayerMongoRepository>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    internal class SystemInfo : ISystemInfo 
    {
        public string ConnectionString { get; set; }
        public string Persistence { get; set; }
        public string DataBase { get; set; }

        IConfigurationRoot root;
        SystemInfo settings;
        private static void GetSettings(out IConfigurationRoot root, out SystemInfo settings)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            root = builder.Build();
            settings = root.GetSection("AppSettings").Get<SystemInfo>();
        }
        public void FillSettings()
        {
            GetSettings(out root, out settings);
            ConnectionString = root.GetConnectionString(settings.Persistence);
            DataBase = settings.DataBase;
            Persistence = settings.Persistence; 
        }
    }
}
