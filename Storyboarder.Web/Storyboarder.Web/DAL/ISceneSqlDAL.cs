using Storyboarder.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboarder.Web.DAL
{
    public interface ISceneSqlDAL
    {
        /// <summary>
        /// Gets all the scenes for a given board from the database 
        /// </summary>
        /// <returns></returns>
        IList<Scene> GetAllScenes();

        /// <summary>
        /// Gets a scene given its ID
        /// </summary>
        /// <param name="sceneId">The id number of the scene in the database.</param>
        /// <returns>The scene with the given id as a scene object.</returns>
        Scene GetScene(int sceneId);

        /// <summary>
        /// Updates the scene with new information
        /// </summary>
        /// <param name="scene">The scene object with the updated properties.</param>
        void UpdateScene(Scene scene);

        /// <summary>
        /// Deletes a scene from the database
        /// </summary>
        /// <param name="cardId">The id of the scene to be deleted.</param>
        void DeleteScene(int cardId);
    }
}
