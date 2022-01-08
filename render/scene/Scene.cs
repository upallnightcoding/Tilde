using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde;
using Tilde.render.entity;

namespace Tilde.render.scene
{
    public class Scene
    {
        private List<Entity> entityList = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Scene()
        {
            entityList = new List<Entity>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Add() - Adds an Entity object to th list of entities.  If the
        /// entity is null, the entity is not added to the list.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Entity entity)
        {
            if (entity != null)
            {
                entityList.Add(entity);
            }
        }

        /// <summary>
        /// Initialize() - 
        /// </summary>
        public void Initialize()
        {
            foreach (Entity entity in entityList)
            {
                entity.Initialize();
            }
        }

        public void Update()
        {
            foreach (Entity entity in entityList)
            {
                entity.Update();
            }
        }

        /// <summary>
        /// Display() - 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="camera"></param>
        public void Display(double time, Camera camera)
        {
            foreach (Entity entity in entityList)
            {
                entity.Display(time, camera);
            }
        }
    }
}
