using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using WcfService2.Model;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public SellerRegisterRes RegisterSeller(SellerRegisterReq sellerRegisterReq)
        {
            SellerRegisterRes registerSellerRes = new SellerRegisterRes();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("insert_seller_info", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        command.Parameters.AddWithValue("email", sellerRegisterReq.email);
                        command.Parameters.AddWithValue("password",  sellerRegisterReq.password);
                        command.Parameters.AddWithValue("username", sellerRegisterReq.username);
                       

                        // Add any other parameters as needed

                        // Execute the function and get the result
                        bool result = (bool)command.ExecuteScalar();

                        if (result)
                        {
                            registerSellerRes.IsSuccess = true;
                            registerSellerRes.Message= "OK";

                        }
                        else
                        {
                            registerSellerRes.IsSuccess = false;
                            registerSellerRes.Message = "Error";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                registerSellerRes.IsSuccess = false;

            }
            return registerSellerRes;
        }

        public SellerLoginRes LoginSeller(SellerLoginReq sellerLoginReq)
        {
            SellerLoginRes res= new SellerLoginRes();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("login_seller", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        
                        command.Parameters.AddWithValue("par_username", sellerLoginReq.password);
                        command.Parameters.AddWithValue("par_password", sellerLoginReq.username);


                        // Add any other parameters as needed

                        // Execute the function and get the result
                        bool result = (bool)command.ExecuteScalar();

                        if (result)
                        {
                            res.IsSuccess = true;
                            res.Message = "OK";

                        }
                        else
                        {
                            res.IsSuccess = false;
                            res.Message = "wrong username or password";
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public AddProductRes AddProduct(Product product)
        {
            AddProductRes res = new AddProductRes();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("add_product", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command



                        command.Parameters.AddWithValue("product_name", product.Name);
                        command.Parameters.AddWithValue("product_price", product.Price);
                        command.Parameters.AddWithValue("product_color", product.Color);
                        command.Parameters.AddWithValue("product_category", product.Category);
                        command.Parameters.AddWithValue("product_description", product.Description);
                        command.Parameters.AddWithValue("product_url", product.Url);


                        // Add any other parameters as needed

                        // Execute the function and get the result
                        bool result = (bool)command.ExecuteScalar();

                        if (result)
                        {
                            res.IsSuccess = true;
                            res.Message = "OK";

                        }
                        else
                        {
                            res.IsSuccess = false;
                            res.Message = "wrong username or password";
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("get_all_products", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Color = reader.GetString(3),
                                Category = reader.GetString(4),
                                Description = reader.GetString(5),
                                Url = reader.GetString(6)
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

    }
}
