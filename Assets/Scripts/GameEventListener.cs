using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent unityEvent;
    private void OnEnable() => gameEvent.Register(this);
    private void OnDisable() => gameEvent.Deregister(this);
    public void RaiseEvent() => unityEvent?.Invoke();

}
