using System.Net;
using System.Net.Http;
using System.Web.Http;
using GM.Business.Layer;
using GM.Business.Entity;
using System.Web.Http;
using System.Collections.Generic;

namespace GloboMart.Controllers
{
    [RoutePrefix("api")]
    public class GMAPIController : ApiController
    {
        ProductLayer prodLayer = new ProductLayer();

        [Route("Products")]
        public IEnumerable<ProductModel> Get()
        {
            var result = prodLayer.GetProducts();
            return result;
        }

        [Route("Product/{code}")]
        public ProductModel Get(string code)
        {
            var result = prodLayer.GetProduct(code);
            return result;
        }

        [Route("AddProduct")]
        public string Post(ProductModel product)
        {
            var result = prodLayer.AddProduct(product);
            return result;
        }

        [Route("EditProduct/{code}")]
        public bool Put(string code, ProductModel product)
        {
            var result = prodLayer.EditProduct(product);
            return result;
        }

        [Route("DeleteProduct/{code}")]
        public bool Delete(string code)
        {
            var result = prodLayer.DeleteProduct(code);
            return result;
        }
    }
}
