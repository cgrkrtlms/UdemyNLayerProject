using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.Web.Filters
{
    // Eğerki Filter'larımız Dependency Injection nesnesi alıyorsa , onu önce startup dosyasonda addScope olarak eklememiz gerekir.Daha sonra Controller tarafında [ServiceFilter(typeof(NotFoundFilter))] şeklinde attribute olarak eklememiz gerekir. 

    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;
        // private readonly IService<Category> _categoryService;  Bu şekildede kullanabilirdik.

        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add($"id'si {id} olan kategori veritabanında bulunamadı!");

                context.Result = new RedirectToActionResult("Error","Home",errorDto);
            }
        }
    }
}
