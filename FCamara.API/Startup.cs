using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using FCamara.DAL.Produto;
using FCamara.DAL.Produto.Interfaces;
using FCamara.DAL.Usuario;
using FCamara.DAL.Usuario.Interfaces;
using FCamara.Service.Autenticacao.Token;
using FCamara.Service.Autenticacao.Token.Interfaces;
using FCamara.Service.Autenticacao.Usuario;
using FCamara.Service.Autenticacao.Usuario.Interfaces;
using FCamara.Service.Interfaces.Produto;
using FCamara.Service.Produto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FCamara.API
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
            services.AddCors();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IUsuarioDAL, UsuarioDAL>();
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<IProdutoDAL, ProdutoDAL>();
            services.AddSingleton<IProdutoService, ProdutoService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
