using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Game Event", menuName ="New Game Event", order = 1)]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.RaiseEvent();
        }
    }

    public void Register(GameEventListener gameEventListener) => listeners.Add(gameEventListener);
    public void Deregister(GameEventListener gameEventListener) => listeners.Remove(gameEventListener);
}
