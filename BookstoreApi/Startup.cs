using BookstoreApi.Mappings;
using BookstoreApi.Repositories;
using BookstoreApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookstoreApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // If development, then Use an in memory DB
            if (Environment.IsDevelopment())
            {
                var inMemoryDatabaseName = "Bookstore";
                services.AddDbContext<IBookContext, BookstoreContext>(opt => opt.UseInMemoryDatabase(inMemoryDatabaseName));
                services.AddDbContext<IAuthorContext, BookstoreContext>(opt => opt.UseInMemoryDatabase(inMemoryDatabaseName));
            }
            else
            {
                services.AddDbContext<IBookContext, BookstoreContext>();
                services.AddDbContext<IAuthorContext, BookstoreContext>();
            }

            services.AddControllers();

            var mapper = MappingProfileConfiguration.InitializeAutoMapper().CreateMapper();
            services.AddSingleton(mapper);

            services
                .AddTransient<IBookService, BookService>()
                .AddTransient<IAuthorService, AuthorService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
