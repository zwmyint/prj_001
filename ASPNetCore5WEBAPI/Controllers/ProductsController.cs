using System;
using System.ComponentModel.DataAnnotations;
using ASPNetCore5WEBAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore5WEBAPI.Controllers
{
    // this ApiController will take care of model validation
    [ApiController]
    [Route("api/[controller]")]
    //[DebugResourceFilter] // added this globally at startup.cs
    [DebugActionFilter]
    //[TokenAuthenticationFilter] // this mean, every action method need Authentication
    [TokenAuthenticationJWTFilter] // for JWT
    public class ProductsController : ControllerBase
    {
        /* [HttpGet]
        public string Get()
        {
            // -- filter pipeline for each task
            // Authentication / authorization
            // Generic validation = [DebugResourceFilter]
            // Retrieve input data
            // Input data validation = [DebugActionFilter]
            // Application logic <<< developer more focus on this.
            // Format output data
            // Exception handling
            // -- filter pipeline for each task

            https://localhost:5001/api/products
            return "Lots of products";
        } */
        
        [HttpGet("{id}")]
        public string GetById(int id, [FromQuery] bool isActive)
        {
            //https://localhost:5001/api/products/10
            //https://localhost:5001/api/products/10?isActive=True
            return $"Lots of products: {id}, status: {isActive}";
        }

        [HttpGet]
        public string GetByObject([FromQuery] ProductDTO productDTO)
        {
            //https://localhost:5001/api/products
            //https://localhost:5001/api/products?Id=20&name=myproduct
            return $"product id: {productDTO.Id}, name: {productDTO.Name}";
        }

        [HttpPost]
        public IActionResult Post(ProductDTO productDTO)
        {
            /* 
            // this is before custom validation logic (before added ReleasedDateInPast class)
            // ModelState come from ControllerBase
            if (productDTO.ReleasedDate >= DateTime.Today){
                ModelState.AddModelError(nameof(productDTO.ReleasedDate),"The Product's release date has to be in the past.");
                return BadRequest(ModelState);
            } */

            //https://localhost:5001/api/products
            return Ok($"product id: {productDTO.Id}, name: {productDTO.Name}");

            /* {
                "Id": 2001,
                "Name": "ZAW",
                "ReleasedDate": "2021-01-10"
                }
            */
        }

        //
    }

    public class ProductDTO
    {
        //DataAnnotations
        [Required]
        public int Id {get; set;}

        //DataAnnotations
        [Required]
        [StringLength(20, ErrorMessage = "The name has to be less than 10 char long.")]
        public string Name {get; set;}

        // custom logic
        [ReleasedDateInPast]
        public DateTime ReleasedDate{get; set;}

    }

    public class ReleasedDateInPast: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var productDTO = (ProductDTO)validationContext.ObjectInstance;
            if(productDTO.ReleasedDate >= DateTime.Today) 
            {
                return new ValidationResult("The Product's release date has to be in the past.");
            }

            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }




    //

}
