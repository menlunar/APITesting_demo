using Dapper;
using DemoAPI.Interfaces;
using DemoAPI.Models;
using System.Data.SqlClient;

namespace DemoAPI.Repository
{
    public class ConfigRepository : IConfigRepository
    {
        public ConfigModel GetConfig()
        {
            using (var connection = new SqlConnection("Data Source=LAPTOP-88E4JEB2\\SQLEXPRESS;Initial Catalog=DemoAPI;User ID=sa;Password=admin;Persist Security Info=True;"))
            {
                connection.Open();

                // Define the query to get the configuration (assuming the column is named 'mass_unit')
                string query = "SELECT mass_unit AS Mass_Unit FROM config";

                // Execute the query and map the result to the ConfigModel
                var config = connection.QuerySingleOrDefault<ConfigModel>(query);

                return config;
            }
        }
    }
}
