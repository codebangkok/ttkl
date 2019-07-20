using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TtkLib.Models;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace TtklApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IConfiguration config;

        public ProductsController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var con = new SqlConnection(config.GetConnectionString("Northwind"));
            var com = con.CreateCommand();
            com.CommandText = "Products_SelectAll";
            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            var reader = com.ExecuteReader();

            var products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product();
                product.ProductID = (int)reader["ProductID"];
                product.ProductName = reader["ProductName"].ToString();
                product.SupplierID = (int)reader["SupplierID"];
                product.CategoryID = (int)reader["CategoryID"];
                product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                product.UnitPrice = (decimal)reader["UnitPrice"];
                product.UnitsInStock = (short)reader["UnitsInStock"];
                product.UnitsOnOrder = (short)reader["UnitsOnOrder"];
                product.ReorderLevel = (short)reader["ReorderLevel"];
                product.Discontinued = (bool)reader["Discontinued"];
                product.SupplierName = reader["SupplierName"].ToString();
                product.CategoryName = reader["CategoryName"].ToString();

                products.Add(product);
            }
            reader.Close();
            con.Close();

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Product>> GetById(int id)
        {
            var con = new SqlConnection(config.GetConnectionString("Northwind"));
            var com = con.CreateCommand();
            com.CommandText = "Products_SelectById";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("ProductId", id);
            con.Open();
            var reader = com.ExecuteReader();

            var products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product();
                product.ProductID = (int)reader["ProductID"];
                product.ProductName = reader["ProductName"].ToString();
                product.SupplierID = (int)reader["SupplierID"];
                product.CategoryID = (int)reader["CategoryID"];
                product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                product.UnitPrice = (decimal)reader["UnitPrice"];
                product.UnitsInStock = (short)reader["UnitsInStock"];
                product.UnitsOnOrder = (short)reader["UnitsOnOrder"];
                product.ReorderLevel = (short)reader["ReorderLevel"];
                product.Discontinued = (bool)reader["Discontinued"];
                product.SupplierName = reader["SupplierName"].ToString();
                product.CategoryName = reader["CategoryName"].ToString();

                products.Add(product);
            }
            reader.Close();
            con.Close();

            return products;
        }

        [HttpGet("{name}")]
        public ActionResult<List<Product>> GetByName(string name)
        {
            var con = new SqlConnection(config.GetConnectionString("Northwind"));
            var com = con.CreateCommand();
            com.CommandText = "Products_SelectByName";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("ProductName", name);
            con.Open();
            var reader = com.ExecuteReader();

            var products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product();
                product.ProductID = (int)reader["ProductID"];
                product.ProductName = reader["ProductName"].ToString();
                product.SupplierID = (int)reader["SupplierID"];
                product.CategoryID = (int)reader["CategoryID"];
                product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                product.UnitPrice = (decimal)reader["UnitPrice"];
                product.UnitsInStock = (short)reader["UnitsInStock"];
                product.UnitsOnOrder = (short)reader["UnitsOnOrder"];
                product.ReorderLevel = (short)reader["ReorderLevel"];
                product.Discontinued = (bool)reader["Discontinued"];
                product.SupplierName = reader["SupplierName"].ToString();
                product.CategoryName = reader["CategoryName"].ToString();

                products.Add(product);
            }
            reader.Close();
            con.Close();

            return products;
        }

        [HttpPost]
        public bool Post([FromBody]Product product)
        {
            var con = new SqlConnection(config.GetConnectionString("Northwind"));
            var com = con.CreateCommand();
            com.CommandText = "Products_Insert";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("ProductName", product.ProductName);
            com.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
            com.Parameters.AddWithValue("Discontinued", product.Discontinued);

            con.Open();
            var affected = com.ExecuteNonQuery();
            con.Close();

            return affected > 0;
        }

        [HttpPut]
        public bool Put([FromBody]Product product)
        {
            var con = new SqlConnection(config.GetConnectionString("Northwind"));
            var com = con.CreateCommand();
            com.CommandText = "Products_Update";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("ProductName", product.ProductName);
            com.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
            com.Parameters.AddWithValue("Discontinued", product.Discontinued);
            com.Parameters.AddWithValue("ProductId", product.ProductID);

            con.Open();
            var affected = com.ExecuteNonQuery();
            con.Close();

            return affected > 0;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var con = new SqlConnection(config.GetConnectionString("Northwind"));
            var com = con.CreateCommand();
            com.CommandText = "Products_Delete";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("ProductId", id);

            con.Open();
            var affected = com.ExecuteNonQuery();
            con.Close();

            return affected > 0;
        }
    }
}
