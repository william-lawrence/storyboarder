﻿using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public class BoardSqlDAL : IBoardDAL
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
        public BoardSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets all the boards using the rows in the database.
        /// </summary>
        /// <returns>A list of the boards.</returns>
        public IList<Board> GetAllBoardsForUser(int userId)
        {
            IList<Board> boards = new List<Board>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // The SQL command to get all boards from the database
                    string sql = $@"SELECT * FROM boards
                                    WHERE boards.user_id = @userId;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
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
        /// Gets the information for a specific 
        /// </summary>
        /// <param name="boardId"></param>
        /// <returns></returns>
        public Board GetBoard(int boardId)
        {
            Board board = new Board();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // The SQL command to get the specific board from the database
                    // by using its ID.
                    string sql = "SELECT * FROM boards WHERE boards.id = @boardId;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@boardId", boardId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        board.Id = Convert.ToInt32(reader["id"]);
                        board.Title = Convert.ToString(reader["title"]);
                        board.Description = Convert.ToString(reader["description"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return board;
        }

        /// <summary>
        /// Updates a given board in the database
        /// </summary>
        /// <param name="board">The board to be updated</param>
        public void UpdateBoard(Board board)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL to change the description in the database
                    string sql = "UPDATE boards SET description = @boardDescription WHERE id = @boardId;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@boardDescription", board.Description);
                    command.Parameters.AddWithValue("@boardId", board.Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a given board.
        /// </summary>
        /// <param name="board">The board to be deleted.</param>
        public void DeleteBoard(int boardId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL to delete a given board.
                    // @id is the id of the board passed through the method.
                    string sql = "DELETE FROM boards WHERE boards.id = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", boardId);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Maps the rows of the board table to a Board object.
        /// </summary>
        /// <param name="reader">The data reader that is being used to get the data from the database.</param>
        /// <returns>A board object whose properties match the row used to generate it.</returns>
        private Board MapRowToBoard(SqlDataReader reader)
        {
            Board board = new Board
            {
                Id = Convert.ToInt32(reader["id"]),
                Title = Convert.ToString(reader["title"]),
                Description = Convert.ToString(reader["description"])
            };

            return board;
        }
    }
}

