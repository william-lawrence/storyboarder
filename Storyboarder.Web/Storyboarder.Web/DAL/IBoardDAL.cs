using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public interface IBoardDAL
    {
        /// <summary>
        /// Gets all the boards from the database.
        /// </summary>
        /// <returns>A list of all the boards in the database as a board object.</returns>
        IList<Board> GetAllBoardsForUser(int userId);

        /// <summary>
        /// Gets a board given its ID.
        /// </summary>
        /// <param name="boardId">The id number of the board in the database</param>
        /// <returns>The board with the given id as a a board object.</returns>
        Board GetBoard(int boardId);

        /// <summary>
        /// Updates the board with new information.
        /// </summary>
        /// <param name="board">The board object with updated properties.</param>
        void UpdateBoard(Board board);

        /// <summary>
        /// Deletes a particular row from the database corresponding to a board.
        /// </summary>
        /// <param name="board">The id of the board to be deleted.</param>
        void DeleteBoard(int boardId);
    }
}
