using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public interface ICardSqlDAL
    {
        /// <summary>
        /// Gets all the cards for a given board from the database 
        /// </summary>
        /// <returns></returns>
        IList<Card> GetAllCards();

        /// <summary>
        /// Gets a card given its ID
        /// </summary>
        /// <param name="cardId">The id number of the card in the database.</param>
        /// <returns>The card with the given id as a card object.</returns>
        Card GetCard(int cardId);

        /// <summary>
        /// Updates the card with new information
        /// </summary>
        /// <param name="card">The card object with the updated properties.</param>
        void UpdateCard(Card card);

        /// <summary>
        /// Deletes a card from the database
        /// </summary>
        /// <param name="cardId">The id of the card to be deleted.</param>
        void DeleteCard(int cardId);
    }
}
