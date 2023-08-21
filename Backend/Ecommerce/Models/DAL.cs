using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Models
{
    // Data Access Layer
    public class DAL
    {
        public Response register(Users users, SqlConnection connection){
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_register", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Fund", 0);
            cmd.Parameters.AddWithValue("@Type", "Users");
            cmd.Parameters.AddWithValue("@Type", "Pending");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0){
                response.StatusCode = 200;
                response.StatusMessage = "User registered successfully";
            }
            else{
                response.StatusCode = 100;
                response.StatusMessage = "User registration failed";
            }
            
            return response;
        }

        public Response Login(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0){
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.StatusMessage = "User is valid";
                response.User = user;
            }
            else{
                response.StatusCode = 100;
                response.StatusMessage = "User is invalid";
                response.User = null;
            }
            return response;
        }

        public Response ViewUser(Users users, SqlConnection connection){
            SqlDataAdapter da = new SqlDataAdapter("p_viewUser", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0){
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                response.StatusCode = 200;
                response.StatusMessage = "User exists";
            }
            else{
                response.StatusCode = 100;
                response.StatusMessage = "User does not exist";
                response.User = user;
            }
            return response;
        }

        public Response UpdateProfile(Users users, SqlConnection connection){
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0){
                response.StatusCode = 200;
                response.StatusMessage = "Record updated succesfully";
            } 
            else {
                response.StatusCode = 100;
                response.StatusMessage = "Error Occured";
            }

            return response;
        }

        public Response AddToCart(Cart cart, SqlConnection connection){
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", cart.UserId);
            cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            cmd.Parameters.AddWithValue("@MedicineID", cart.MedicineID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0){
                response.StatusCode = 200;
                response.StatusMessage = "Record updated succesfully";
            } 
            else {
                response.StatusCode = 100;
                response.StatusMessage = "Error Occured";
            }

            return response;
        }

        public Response PlaceOrder(Users users, SqlConnection connection){
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
            cmd.Parameters.Add("@ID", (SqlDbType)users.ID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0){
                response.StatusCode = 200;
                response.StatusMessage = "Order placed succesfully";
            } 
            else {
                response.StatusCode = 100;
                response.StatusMessage = "Error Occured";
            }

            return response;
        }

        public Response OrderList(Users users, SqlConnection connection){
            Response response = new Response();
            List<Orders> ListOrders = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0){
                for(int i = 0; i < dt.Rows.Count; i++){
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    ListOrders.Add(order);
                }

                if (ListOrders.Count > 0){
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details found";
                    response.ListOrders = ListOrders;
                } else{
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details not found";
                    response.ListOrders = null;
                }
            } else{
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details not found";
                    response.ListOrders = null;
                }

            return response;
        }

        public Response AddUpdateMedicine(Medicines medicines, SqlConnection connection){
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateMedicine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", medicines.Name);
            cmd.Parameters.AddWithValue("@Manufacturer", medicines.Manufacturer);
            cmd.Parameters.AddWithValue("@UnitPrice", medicines.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", medicines.Discount);
            cmd.Parameters.AddWithValue("@Quantity", medicines.Quantity);
            cmd.Parameters.AddWithValue("@ExpDate", medicines.ExpDate);
            cmd.Parameters.AddWithValue("@ImageUrl", medicines.ImageUrl);
            cmd.Parameters.AddWithValue("@Status", medicines.Status);
            cmd.Parameters.AddWithValue("@Type", medicines.Type);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0){
                response.StatusCode = 200; 
                response.StatusMessage = "Medicine inserted successfully";
            } else {
                response.StatusCode = 100;
                response.StatusMessage = "Medicine failed to insert";
            }

            return response;
        }

        public Response UsersList(Users users, SqlConnection connection){
            Response response = new Response();
            List<Users> ListUsers = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter("sp_UsersList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0){
                for(int i = 0; i < dt.Rows.Count; i++){
                    Users user = new Users();
                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);
                    user.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    ListUsers.Add(user);
                }

                if (ListUsers.Count > 0){
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details found";
                    response.ListUsers = ListUsers;
                } else{
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details not found";
                    response.ListUsers = null;
                }
            } else{
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details not found";
                    response.ListUsers = null;
                }

            return response;
        }

    }
}