using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.Models
{
    public class Board
    {
        /// <summary>
        /// The id of the board in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the board.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the story in the board.
        /// </summary>        
        public string Description { get; set; }
    }
}
