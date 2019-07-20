using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TtkLib.Models;

namespace TtklApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var con = new SqlConnection("Server=192.168.64.112; Database=Northwind; User ID=sa; Password=P@ssw0rd");
            var com = con.CreateCommand();
            com.CommandText = @"
select 
	p.*, 
	s.CompanyName as SupplierName,
	c.CategoryName
from products p
join Suppliers s on s.SupplierID=p.SupplierID
join Categories c on c.CategoryID=p.CategoryID";            
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
    }
}
