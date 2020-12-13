using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Advertises
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
            services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.ExpireTimeSpan = TimeSpan.FromDays(10);
                });


            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            //services.AddControllersWithViews();
            
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddRazorPagesOptions(options =>
                {
                    /*options.Conventions.AuthorizeFolder("/Advertisements/");
                    options.Conventions.AuthorizeFolder("/Categories");
                    options.Conventions.AuthorizeFolder("/Cities");
                    options.Conventions.AuthorizeFolder("/Local");
                    options.Conventions.AllowAnonymousToFolder("/Account");
                    options.Conventions.AllowAnonymousToPage("/Index");*/
                })
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);


            services
                .AddTransient<IAdvertismentService, AdvertismentService>()
                .AddTransient<IBaseService<Category>, BaseService<Category>>()
                .AddTransient<IBaseService<City>, BaseService<City>>()
                .AddTransient<IBaseService<Local>, BaseService<Local>>()
                .AddTransient<IBaseService<Role>, BaseService<Role>>()
                .AddTransient<IBaseService<User>, BaseService<User>>()
                .AddTransient<IBaseService<InnerCategory>, BaseService<InnerCategory>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //ADD ME


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}