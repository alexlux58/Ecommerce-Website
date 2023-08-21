using System.Data.SqlClient;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration){
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddUpdateMedicine")]
        public Response AddUpdateMedicine(Medicines medicines){
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dal.AddUpdateMedicine(medicines, connection);

            return response;
        }

        [HttpGet]
        [Route("UsersList")]
        public Response UsersList(Users users){
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dal.UsersList(users, connection);

            return response;
        }
    }

}