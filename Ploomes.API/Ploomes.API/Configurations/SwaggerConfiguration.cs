﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Ploomes.API.Configurations
{
    public class SwaggerConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public SwaggerConfiguration(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Title = $"Ploomes API {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = "API REST desenvolvida com o ASP.NET Core 3.1",
                        Contact = new OpenApiContact
                        {
                            Name = "Teste Prático Ploomes",
                            Url = new Uri("https://www.ploomes.com/")
                        }
                    });
            }
        }
    }
}
