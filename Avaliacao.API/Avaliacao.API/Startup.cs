using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Avaliacao.API.Business.Interfaces.Services;
using Avaliacao.API.Configurations;
using Avaliacao.API.Extensions;
using Avaliacao.API.Middlewares;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;


namespace Avaliacao.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfiguration>();

            services.ResolveDependencies();

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider,
            IDBUpService dBUpService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    string swaggerJsonBasePath = (String.IsNullOrEmpty(c.RoutePrefix) ? "." : "..");
                    string endPoint = $"{swaggerJsonBasePath}/swagger/" + description.GroupName + "/swagger.json";
                    c.SwaggerEndpoint(endPoint, $"Avaliacao - {description.GroupName.ToUpperInvariant()}");
                }

                c.DocExpansion(DocExpansion.List);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ExceptionMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DBUpConfiguration.Inicializacao(dBUpService, Configuration).Wait();
        }
    }
}
