using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameEvent", order = 1)]
public class GameEvent : ScriptableObject
{
    public delegate void NextTurn();
    public event NextTurn OnNextTurn;

    public delegate void EndGame();
    public event EndGame OnEndGame;

    private List<GameEventSubscriber> subscribers =
        new List<GameEventSubscriber>();

    public void FireEvent(string eventName)
    {
        for (int i = 0; i < subscribers.Count; ++i)
        {
            subscribers[i].OnEventFired(eventName);
        }
    }

    public static GameEvent operator +(GameEvent evt, GameEventSubscriber sub)
    {
        evt.subscribers.Add(sub);
        return evt;
    }

    public static GameEvent operator -(GameEvent evt, GameEventSubscriber sub)
    {
        evt.subscribers.Remove(sub);
        return evt;
    }
}
