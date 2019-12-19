using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ExploreSolution.Services;
using ExploreSolution.API.Services;
using Explore.Services.Services;
using Explore.Services.Abstraction;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Repositories;
using Explore.DataAccess.Abstraction.Entities;
using ExploreSolution.API.GraphQL.Scheme;
using ExploreSolution.API.GraphQL;
using ExploreSolution.API.GraphQL.SchemeQl;
using GraphQL.Server;
using GraphQL;
using ExploreSolution.API.Middleware;
using Explore.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ExploreSolution
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddDbContext<ExploreDb>(options =>
            {
                options.UseSqlServer(@"Server=tcp:exploresolutionapidbserver.database.windows.net,1433;Initial Catalog=ExploreSolutionAPI_db;Persist Security Info=False;User ID=oleg;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });

            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Graph QL
            services.AddSingleton<TourType>();
            services.AddSingleton<ToursQuery>();
            services.AddSingleton<TourScheme>();
            services.AddSingleton<IDependencyResolver>(
                c=> new FuncDependencyResolver(type => 
                c.GetRequiredService(type)));
            //services.AddGraphQLHttp();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            });

            // Get secret
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "Api Documentation",
                    TermsOfService = "None"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            app.UseDeveloperExceptionPage();
            app.UseMiddleware<CustomHeaderMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { });

            app.UseGraphQL<TourScheme>("/graphql");
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
