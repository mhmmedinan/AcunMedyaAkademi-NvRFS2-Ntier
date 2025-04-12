using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace AcunMedyaAkademi_NvRFS2_NTier.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly string _connectionString;

    public BrandsController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AdonetConnection");
    }

    [HttpGet] //HttpPost,HttpPut,HttpDelete
    public IActionResult GetBrands()
    {
        var brands = new List<Brand>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "select Id,Name from Brands";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            
            }
            connection.Close();
        }






        //200 döner 
        return Ok(brands);  // Http Status Code
    }



    [HttpGet("{name}")] //HttpPost,HttpPut,HttpDelete
    public IActionResult GetBrandName(string name)
    {
        var brands = new List<Brand>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "select Id,Name from Brands where Name= '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });

            }
            connection.Close();
        }






        //200 döner 
        return Ok(brands);  // Http Status Code
    }


    //localhost:5000/api/brands/getbyid/2
    [HttpGet("getbyid/{id}")] //HttpPost,HttpPut,HttpDelete
    public IActionResult GetById([FromRoute]int id)
    {
        //200 döner 
        return Ok("İşlem başarılı");  // Http Status Code
    }


}
