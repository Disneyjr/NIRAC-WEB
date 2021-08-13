using System.Web.Http;
using WebActivatorEx;
using NIRAC_API;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace NIRAC_API
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "NIRAC_API");
                        c.IncludeXmlComments(GetXMLPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }

        private static string GetXMLPath()
        {
            return String.Format(@"{0}\Docs\NIRAC-API.xml", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
