using LoyaltyPrime.Presistance;
using LoyaltyPrime.Presistance.CoreImplementation;
using LoyaltyPrime.Presistance.CoreImplementation.Factories;
using LoyaltyPrime.Presistance.CoreImplementation.Repositories;
using LoyaltyPrime.Service.Implementation.Services;
using LoyaltyPrime.Service.Implementation.ServiceValidators;
using LoyaltyPrime.Service.Implementation.Validators;
using LoyaltyPrime.Service.Interfaces;
using LoyaltyPrime.Service.Interfaces.Factories;
using LoyaltyPrime.Service.Interfaces.FileServices;
using LoyaltyPrime.Service.Interfaces.Repositories;
using LoyaltyPrime.Service.Interfaces.Services;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Interfaces.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LoyaltyPrime
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
            services.AddHttpClient();
            services.AddDbContext<ILoyaltyPrimeDBEntities, LoyaltyPrimeDBEntities>(o => o.UseSqlServer(Configuration.GetConnectionString("LoyaltyPrimeConnectionString")));
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient(provider => new Lazy<IMemberService>(provider.GetService<IMemberService>));
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient(provider => new Lazy<IMemberRepository>(provider.GetService<IMemberRepository>));
            services.AddTransient<IMemberServiceValidator, MemberServiceValidator>();
            services.AddTransient(provider => new Lazy<IMemberServiceValidator>(provider.GetService<IMemberServiceValidator>));
            services.AddTransient<IMemberValidator, MemberValidator>();
            services.AddTransient(provider => new Lazy<IMemberValidator>(provider.GetService<IMemberValidator>));
            services.AddTransient<IMemberFactory, MemberFactory>();
            services.AddTransient(provider => new Lazy<IMemberFactory>(provider.GetService<IMemberFactory>));
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient(provider => new Lazy<IAccountService>(provider.GetService<IAccountService>));
            services.AddTransient<IAccountServiceValidator, AccountServiceValidator>();
            services.AddTransient(provider => new Lazy<IAccountServiceValidator>(provider.GetService<IAccountServiceValidator>));
            services.AddTransient<IAccountValidator, AccountValidator>();
            services.AddTransient(provider => new Lazy<IAccountValidator>(provider.GetService<IAccountValidator>));
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient(provider => new Lazy<IAccountRepository>(provider.GetService<IAccountRepository>));
            services.AddTransient<IAccountFactory, AccountFactory>();
            services.AddTransient(provider => new Lazy<IAccountFactory>(provider.GetService<IAccountFactory>));
            services.AddTransient<IMediaService, MediaService>();
            services.AddTransient(provider => new Lazy<IMediaService>(provider.GetService<IMediaService>));
            services.AddTransient<IFileServiceValidator, FileServiceValidator>();
            services.AddTransient(provider => new Lazy<IFileServiceValidator>(provider.GetService<IFileServiceValidator>));
            services.AddTransient<IFileService, FileValidator>();
            services.AddTransient(provider => new Lazy<IFileService>(provider.GetService<IFileService>));

            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loyalty Prime");
            });
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
}
