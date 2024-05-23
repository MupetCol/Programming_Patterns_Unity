using UnityEngine;
using System.Collections.Generic;

namespace GPP
{
    public class CommandInvoker : MonoBehaviour
    {     

        public CommandActor currentActor;
        [SerializeField] private CommandInputHandler commandInputHandler;
        private Stack<Command> _commands = new Stack<Command>();

        private void Update()
        {
            var command = commandInputHandler.HandleInput();

            if(command != null){
                Add(command);

                //Inmmediate execute
                command.Execute(currentActor);
            }
        }

        public void Add(Command command)
        {
            _commands.Push(command);
        }

        //BELOW FOR BUTTONS

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute(currentActor);
            }
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                var command = _commands.Pop();
                command.Undo(currentActor);
            }
        }

        public void Replay()
        {
            Execute();
        }
    }
}