using Tilde.render.entity;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using Tilde.render.entity.transform;
using System.Collections.Generic;
using Tilde.render.behavior.action;

namespace Tilde.render.entity
{
    public abstract class Entity
    {
        private Model model = null;

        private Transform transform = null;

        private List<Action> actionList = null;

        // Abstract Functions
        //-------------------
        protected abstract string CreateEntityTexture();

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Entity()
        {
            model = new Model();

            transform = new Transform();

            actionList = new List<Action>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Initialize()
        {
            model.Initialize();
        }

        public void Display(double time, Camera camera)
        {
            var t = transform.Calculate();

            model.Display(time, camera, t);
        }

        public void Update()
        {
            foreach(Action action in actionList)
            {
                action.Update(this);
            }
        }

        public void Add(Action action)
        {
            if (action != null)
            {
                actionList.Add(action);
            }
        }

        public void Move(float x, float y, float z)
        {
            transform.Move(x, y, z);
        }

        public void Turn(float x, float y, float z)
        {
            transform.Turn(x, y, z);
        }
    }
}
