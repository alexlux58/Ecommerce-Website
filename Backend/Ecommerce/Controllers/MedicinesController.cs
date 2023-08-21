using System.Data.SqlClient;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MedicinesController(IConfiguration configuration){
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddToCart")]
        public Response AddToCart(Cart cart){
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dal.AddToCart(cart, connection);

            return response;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public Response PlaceOrder(Users users){
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dal.PlaceOrder(users, connection);

            return response;
        }

        [HttpGet]
        [Route("OrderList")]
        public Response OrderList(Users users){
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dal.OrderList(users, connection);

            return response;
        }

        
    }
}