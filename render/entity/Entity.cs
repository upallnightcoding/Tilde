using Tilde.render.entity;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using Tilde.render.entity.transform;
using System.Collections.Generic;
using Tilde.render.behavior.action;
using Leo.render.behavior;
using Tilde.render.behavior;

namespace Tilde.render.entity
{
    public abstract class Entity
    {
        // Defines the entity texture and mesh
        private Model model = null;

        // Defines the matrix translation, rotation and scale
        private Transform transform = null;

        private FSM fsm = null;

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
            model.Display(time, camera, transform.Calculate());
        }

        public void Update()
        {
            fsm.Update(this);
        }

        public void Set(FSM fsm)
        {
            this.fsm = fsm;
        }

        public void Add(Action action)
        {
            if (action != null)
            {
                if (fsm == null)
                {
                    State state = new State("Start");
                    state.Add(action);

                    fsm = new FSM();
                    fsm.Add(state);
                } else
                {
                    fsm.Add(action);
                }
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
