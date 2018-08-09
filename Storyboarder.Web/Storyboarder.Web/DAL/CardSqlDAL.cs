using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
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
        /// Gets all the boards from the database.
        /// </summary>
        /// <returns>A list of all the boards in the database as a board object.</returns>
        IList<Board> GetAllBoards()
        {
            return NotImplementedException;
        }

        /// <summary>
        /// Gets a board given its ID.
        /// </summary>
        /// <param name="boardId">The id number of the board in the database</param>
        /// <returns>The board with the given id as a a board object.</returns>
        Board GetBoard(int boardId)
        {
            return NotImplementedException;
        }

        /// <summary>
        /// Updates the board with new information.
        /// </summary>
        /// <param name="board">The board object with updated properties.</param>
        void UpdateBoard(Board board)
        {
            return NotImplementedException;
        }

        /// <summary>
        /// Deletes a particular row from the database corresponding to a board.
        /// </summary>
        /// <param name="board">The id of the board to be deleted.</param>
        void DeleteBoard(int boardId)
        {
            return NotImplementedException;
        }


    }
}
