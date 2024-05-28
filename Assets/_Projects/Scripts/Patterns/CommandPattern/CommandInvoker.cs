using UnityEngine;
using System.Collections.Generic;

namespace GPP
{
    public class CommandInvoker : MonoBehaviour
    {     
        private static CommandActor staticActor;

        [SerializeField] private CommandInputHandler commandInputHandler;
        private static Stack<Command> _commands = new Stack<Command>();


        /*private void Update()
        {
            var command = commandInputHandler.HandleInput();

            if(command != null){
                Add(command);

                //Inmmediate execute
                command.Execute(currentActor);
            }
        }*/

        public static void Add(Command command)
        {
            command.Execute();
            _commands.Push(command);
        }

        //BELOW FOR BUTTONS

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                var command = _commands.Pop();
                command.Undo();
            }
        }

        public void Replay()
        {
            Execute();
        }
    }
}