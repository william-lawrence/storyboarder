using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public interface IBoardDAL
    {
        IList<Board> GetAllBoards();
        Board GetBoard(int boardId);
        void UpdateBoard(Board board);
    }
}
