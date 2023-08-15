using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class UndoHandler : MonoBehaviour
    {
        private Command command = InputHandler.handleInput();
        private Command undoCommand = null;
        private Command redoCommand = null;

        private Queue<Command> replayQueue = new Queue<Command>();

        private Controller _input;

        private void Start()
        {
            _input = new Controller();
            _input.PlayerActions.Undo.Enable();
        }   

        private void Update()
        {
            if (undoCommand != null && _input.PlayerActions.Undo.WasPressedThisFrame())
            {
                undoCommand.Undo();
            }

            command = InputHandler.handleInput();

            if (command is CommandNull || command == null) return;
            replayQueue.Enqueue(command);
            undoCommand = command;
        }

        public void Replay()
        {
            StartCoroutine(ReplayCor());
        }

        private IEnumerator ReplayCor()
        {
            foreach (var comm in replayQueue)
            {
                comm.Execute();
                yield return new WaitForSeconds(.2f);
            }
            
            replayQueue.Clear();
        }
    }