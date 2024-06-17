using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TKS
{
    public class GameEventListener : MonoBehaviour
    {
        [FormerlySerializedAs("Event")] public GameEvent @event;
        [FormerlySerializedAs("Response")] public UnityEvent response;

        private void OnEnable()
        {
            @event.RegisterListener(this);
        }

        private void OnDisable()
        {
            @event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}