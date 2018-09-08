using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public class SceneSqlDAL : ISceneSqlDAL
    {

        // Due to the despondency injection, the ConnectionString property and the constructor are handled
        // in Startup.cs and appsettings.json.

        /// <summary>
        /// The connection string used to access the database.
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// Constructor that takes the connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to get to the needed database.</param>
        public SceneSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets all the cards for a given board from the database 
        /// </summary>
        /// <returns></returns>
        public IList<Scene> GetAllScenes()
        {
            IList<Scene> cards = new List<Scene>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // The SQL command to get all the cards from the database
                    string sql = "SELECT * FROM cards;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cards.Add(MapRowToCard(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return cards;
        }

        /// <summary>
        /// Gets a card given its ID
        /// </summary>
        /// <param name="sceneId">The id number of the card in the database.</param>
        /// <returns>The card with the given id as a card object.</returns>
        public Scene GetScene(int sceneId)
        {
            Scene scene = new Scene();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // The SQL command to get the  specific board from the database by
                    // using its ID. 
                    string sql = "SELECT * FROM cards WHERE cards.id = @sceneId;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@sceneId", sceneId);

                    SqlDataReader reader = command.ExecuteReader();

                    // Add the information from the database to the card.
                    while (reader.Read())
                    {
                        scene.Id = Convert.ToInt32(reader["id"]);
                        scene.BoardId = Convert.ToInt32(reader["board_id"]);
                        scene.Number = Convert.ToInt32(reader["number"]);
                        scene.Title = Convert.ToString(reader["title"]);
                        scene.Description = Convert.ToString(reader["description"]);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return scene;
        }

        /// <summary>
        /// Updates the card with new information
        /// </summary>
        /// <param name="scene">The scene object with the updated properties.</param>
        public void UpdateScene(Scene scene)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL to change the description in the database
                    string sql = "UPDATE cards SET description = @sceneDescription WHERE id = @sceneId;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@sceneDescription", scene.Description);
                    command.Parameters.AddWithValue("@sceneId", scene.Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a card from the database
        /// </summary>
        /// <param name="sceneId">The id of the card to be deleted.</param>
        public void DeleteScene(int sceneId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL to delete a given card.
                    // @id is the id of the card int the database
                    string sql = "DELETE FROM cards WHERE cards.id = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@sceneTd", sceneId);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Maps the rows of the cards table to a card object.
        /// </summary>
        /// <param name="reader">>The data reader that is being used to get the data from the database.</param>
        /// <returns>A card object whose properties match the row used to generate it.</returns>
        private Scene MapRowToCard(SqlDataReader reader)
        {
            Scene scene = new Scene
            {
                Id = Convert.ToInt32(reader["id"]),
                BoardId = Convert.ToInt32(reader["board_id"]),
                Number = Convert.ToInt32(reader["number"]),
                Title = Convert.ToString(reader["title"]),
                Description = Convert.ToString(reader["description"])
            };

            return scene;
        }
    }
}
