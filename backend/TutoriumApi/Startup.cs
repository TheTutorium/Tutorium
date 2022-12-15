using tutorium.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using tutorium.Services.CourseServices;
using tutorium.Filters;

namespace tutorium
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TutoriumContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers(options => options.Filters.Add(typeof(ExceptionHandlingFilter)));
            services.AddEndpointsApiExplorer();  // TODO: I do not know what this do.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0", new OpenApiInfo { Title = "Tutorium", Version = "v0" });
                c.AddSecurityDefinition(
                    "Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Auth",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    } });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICourseService, CourseService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(
                builder => builder.AddDefaultPolicy(
                     a => a.AllowAnyMethod()
               )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v0/swagger.json", "Tutorium API V0"));
            }

            // app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(builder =>
              builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}







