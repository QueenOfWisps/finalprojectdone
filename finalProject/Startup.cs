using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinalProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)//very first class that is launched when site loads. 
            
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services: internal dotnet core. these are services to do the dependency injection.
            services.AddControllersWithViews();
           
            //inject repo into controller.
            services.AddTransient<IForum, ForumRepository>(); //add repository interface and repository class which is forumrepo.
            services.AddDbContext<FinalContext>(options => //adds dbcontext into the service. this site is working under this database. 
            options.UseSqlServer(Configuration["ConnectionStrings:ConnectionString"]));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //
            var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>();
            // gets the instance of FinalContext object as it is configued in the collection of services.
            //hence the name "scope" it takes the final context from the scope defined in the collection of services. 
            //those are defined in configureservices(). 
            //stores that into a service scope vARIABLE
            var context = serviceScope.CreateScope().ServiceProvider.GetRequiredService<FinalContext>();
            //  get the service adddbcontext using finalcontext as a parameter.
            // get requiredservice is a .find for services it is a generic that accepts type <context> as its parameter to get the service.

           // context.Database.EnsureDeleted();
           // context.Database.EnsureCreated();

            if (!context.Users.Any()) //add only if not exist
            {
                //instantiate models
                var userModel = new UserModel();
                // seed data.
                var users = userModel.Seed();
                //add list of models to the user context
                context.Users.AddRange(users);
                //save
                context.SaveChanges();
            }
            /*
            if (!context.QuizUser.Any())
            {
                //instantiate model 
                var quiz = new QuizModel();
                //seed data
                //seed method takes in a list of all users
                var quizuser = quiz.Seed(context.Users.ToList());

                //add full list to user context
                context.QuizUser.AddRange(quizuser);
            }
            */
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
