﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventSubscriber : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent EndGameEvent;
    public UnityEvent NextTurnEvent;

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


    private void OnEnable()
    {
        gameEvent += this;
    }

    private void OnDisable()
    {
        gameEvent -= this;
    }
}