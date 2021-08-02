using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;

        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var obj = _context.Products.Find(42);
            if(obj is null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            var obj = _context.Products.Find(42);
            var newObj = obj.ToString();

            return Ok();
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("BadRequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

        [HttpGet("maths")]
        public ActionResult maths()
        {
            int numerator = 5;
            int denominator = 0;
            int count = numerator / denominator;
            
            return Ok();
        }
    }
}