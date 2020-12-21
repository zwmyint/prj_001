using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore5WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        /* [HttpGet]
        public string Get()
        {
            https://localhost:5001/api/products
            return "Lots of products";
        } */
        
       /*  [HttpGet("{id}")]
        public string GetById(int id, [FromQuery] bool isActive)
        {
            //https://localhost:5001/api/products/10
            //https://localhost:5001/api/products/10?isActive=True
            return $"Lots of products: {id}, status: {isActive}";
        } */

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
            //https://localhost:5001/api/products
            return Ok($"product id: {productDTO.Id}, name: {productDTO.Name}");

            /* {
                "Id": 2001,
                "Name": "ZAW"
            }
            */
        }

        //
    }

    public class ProductDTO
    {
        public int Id {get; set;}
        public string Name {get; set;}
    }

    //

}
