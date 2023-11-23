using Challenge.Common.Exceptions.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Challenge.Common.Exceptions.Exceptions
{
    public static class ExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILog logger)
        { 
            var types = new TypeResponseDictionary();

            app.UseExceptionHandler(appError =>
            {

                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    context.Response.StatusCode = contextFeature.Error is ApiException ?
                                                    (int)(contextFeature.Error as ApiException)._statusCode :
                                                    (int)HttpStatusCode.InternalServerError;

                    //context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                        logger.Error($"Ha ocurrido el siguiente error: {contextFeature.Error}");

                        var type = types.TypeResponse.FirstOrDefault(x => x.Key == context.Response.StatusCode);
                        var message = contextFeature.Error is ApiException ? (contextFeature.Error as ApiException)._message : type.Value;

                        var response = new ResponseError()
                        {
                            StatusCode = type.Key,
                            Response = message
                        }.ToString();

                        await context.Response.WriteAsJsonAsync(response);
                    }
                });
            });
        }
    }
}
