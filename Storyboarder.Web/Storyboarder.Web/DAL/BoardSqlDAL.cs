using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public class BoardSqlDAL : IBoardDAL
    {
        private readonly string ConnectionString;

        public BoardSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IList<Board> GetAllBoards()
        {
            IList<Board> boards = new List<Board>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // The SQL command to get all boards from the database
                    string sql = "SELECT * FROM board;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        boards.Add(MapRowToBoard(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return boards;
        }

        /// <summary>
        /// Maps the rows of the board table to a Board object.
        /// </summary>
        /// <param name="reader">The data reader that is being used to get the data from the database.</param>
        /// <returns>A board object whose properties match the row used to generate it.</returns>
        private Board MapRowToBoard(SqlDataReader reader)
        {
            Board board = new Board();

            board.Id = Convert.ToInt32(reader["id"]);
            board.Title = Convert.ToString(reader["title"]);
            board.FirstName = Convert.ToString(reader["author_first"]);
            board.LastName = Convert.ToString(reader["author_last"]);
            board.Description = Convert.ToString(reader["description"]);

            return board;
        }
    }
}

