using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventSubscriber : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent EndGameEvent;
    public UnityEvent NextTurnEvent;
    public UnityEvent SetCurrentPlayerEvent;
    public UnityEvent RestartGameEvent;

    public void OnEventFired(string eventName)
    {
        StartCoroutine(eventName);
    }

    private IEnumerator NextTurn()
    {
        NextTurnEvent?.Invoke();
        yield return null;
    }

    private IEnumerator EndGame()
    {
        EndGameEvent?.Invoke();
        yield return null;
    }

    private IEnumerator SetCurrentPlayer()
    {
        SetCurrentPlayerEvent?.Invoke();
        yield return null;
    }

    private IEnumerator RestartGame()
    {
        RestartGameEvent?.Invoke();
        yield return null;
    }


    private void OnEnable()
    {
        gameEvent += this;
    }

    private void OnDisable()
    {
        gameEvent -= this;
    }
}
