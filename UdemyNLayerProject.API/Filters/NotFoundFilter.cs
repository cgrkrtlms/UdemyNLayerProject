﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Filters
{
    // Eğerki Filter'larımız Dependency Injection nesnesi alıyorsa , onu önce startup dosyasonda addScope olarak eklememiz gerekir.Daha sonra Controller tarafında [ServiceFilter(typeof(NotFoundFilter))] şeklinde attribute olarak eklememiz gerekir. 

    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;
     // private readonly IService<Product> _productService;  Bu şekildede kullanabilirdik.
        
        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);
            if (product!=null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı!");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
