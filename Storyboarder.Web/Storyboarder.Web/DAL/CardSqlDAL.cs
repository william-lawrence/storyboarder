using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public class CardSqlDAL : ICardSqlDAL
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
        public CardSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets all the cards for a given board from the database 
        /// </summary>
        /// <returns></returns>
        public IList<Card> GetAllCards()
        {
            IList<Card> cards = new List<Card>();

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
        /// <param name="cardId">The id number of the card in the database.</param>
        /// <returns>The card with the given id as a card object.</returns>
        public Card GetCard(int cardId)
        {
            Card card = new Card();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // The SQL command to get the  specific board from the datadase by
                    // using its ID. 
                    string sql = "SELECT * FROM cards WHERE cards.id = @CardId;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@CardId", cardId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        card.Id = Convert.ToInt32(reader["id"]);
                        card.BoardId = Convert.ToInt32(reader["board_id"]);
                        card.Number = Convert.ToInt32(reader["number"]);
                        card.Title = Convert.ToString(reader["title"]);
                        card.Description = Convert.ToString(reader["description"]);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }



            return card;
        }

        /// <summary>
        /// Updates the card with new information
        /// </summary>
        /// <param name="card">The card object with the updated properties.</param>
        public void UpdateCard(Card card)
        {

        }

        /// <summary>
        /// Deletes a card from the database
        /// </summary>
        /// <param name="cardId">The id of the card to be deleted.</param>
        public void DeleteCard(int cardId)
        {

        }

        /// <summary>
        /// Maps the rows of the cards table to a card object.
        /// </summary>
        /// <param name="reader">>The data reader that is being used to get the data from the database.</param>
        /// <returns>A card object whose properties match the row used to generate it.</returns>
        private Card MapRowToCard(SqlDataReader reader)
        {
            Card card = new Card
            {
                Id = Convert.ToInt32(reader["id"]),
                BoardId = Convert.ToInt32(reader["board_id"]),
                Number = Convert.ToInt32(reader["number"]),
                Title = Convert.ToString(reader["title"]),
                Description = Convert.ToString(reader["description"])
            };

            return card;
        }
    }
}
