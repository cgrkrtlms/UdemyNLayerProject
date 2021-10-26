using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Extensions
{
    //Extansion method olması lazım . Bu yüzden static yapmalıyız.
    //Extansion method : .Net framework tarafında var olan objelerin üzerine extra yazdığımız methodlardır.
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder builder) 
        {
            builder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var exp = error.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(exp.Message);

                        //Controllerlarda .Net Framework kendisi Jsona çevirir.Fakat burda response oluştururken kendimiz convert etmeliyiz.
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }

                });
            });
        }
    }
}
