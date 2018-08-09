using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.Models
{
    public class Card
    {
        /// <summary>
        /// The id of the card in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the board that the card is part of in the database.
        /// </summary>
        public int BoardId { get; set; }

        /// <summary>
        /// The number where the scene occurs.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The title of the scene
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of what occurs in the scene.
        /// </summary>
        public string Description { get; set; }
    }
}
