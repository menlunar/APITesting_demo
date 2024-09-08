using DemoAPI.Interfaces;
using DemoAPI.Models;
using Dapper;
using System.Data.SqlClient;

namespace DemoAPI.Repository
{
    public class CharacterRepository : ICharacterRepository
    {

        public bool PostCharacterToDB(CharacterModel character)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=LAPTOP-88E4JEB2\\SQLEXPRESS;Initial Catalog=DemoAPI;User ID=sa;Password=admin;Persist Security Info=True;"))
                {
                    // Open the database connection
                    connection.Open();

                    // Define the SQL query for inserting the character
                    string insertQuery = @"
                    INSERT INTO Character (Id, Name, Birth_Year, Eye_Color, Gender, Hair_Color, Height, Mass, HomeWorld, URL, DateUploaded) 
                    VALUES (@Id, @Name, @Birth_Year, @Eye_Color, @Gender, @Hair_Color, @Height, @Mass, @HomeWorld, @URL, @DateUploaded);
                        ";

                    var parameters = new {
                        Id = character.Id,
                        Name = character.Name,
                        Birth_Year = character.Birth_Year,
                        Eye_Color = character.Eye_Color,
                        Gender = character.Gender,
                        Hair_Color = character.Hair_Color,
                        Height = character.Height,
                        Mass = character.Mass,
                        HomeWorld = character.HomeWorld,
                        URL = character.URL,
                        DateUploaded = DateTime.Now
                        //Created = character.Created,
                        //Edited = character.Edited 
                    };

                    // Execute the insert query with the character data
                    connection.Execute(insertQuery, parameters);

                    connection.Close();

                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}