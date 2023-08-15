using System;
using UnityEngine;

    public class Unit : MonoBehaviour
    {
        private Move moveModule = null;
        private Fire fireModule = null;
        private Jump jumpModule = null;
        
        private Command command = InputHandler.handleInput();
        
        public int x()
        {
            return (int)transform.position.x;
        }
        
        public int y()
        {
            return (int)transform.position.y;
        }

        private void Awake()
        {
            // Assign modules if there are on the object
            if (TryGetComponent<Move>(out Move module00))
            {
                moveModule = module00;
            }
            
            if (TryGetComponent<Jump>(out Jump module01))
            {
                jumpModule = module01;
            }
            
            if (TryGetComponent<Fire>(out Fire module02))
            {
                fireModule = module02;
            }
        }

        public void MoveTo(int x, int y)
        {
            moveModule.UseModule(x, y);
        }

        public void Fire()
        {
            fireModule.UseModule();
        }

        public void Jump()
        {
            jumpModule.UseModule();
        }

        private void Update()
        {
            command = InputHandler.handleInput();

            if (command != null)
            {
                command.Execute();
            }
        }
    }