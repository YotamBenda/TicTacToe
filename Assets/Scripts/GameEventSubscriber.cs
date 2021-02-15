using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameEventSubscriber is used on any GameObject that wants to be subscried to the main Game Event system.
/// All events are exposed to the inspector, assigning through it which function to activate for each event fired.
/// Firing events from GameEvent class, using the Enums names in this class.
/// </summary>
public class GameEventSubscriber : MonoBehaviour
{
    public GameEvent gameEvent;

    public UnityEvent OnEndGame;
    public UnityEvent OnNextTurn;
    public UnityEvent OnSetCurrentPlayer;
    public UnityEvent OnRestartGame;
    public UnityEvent OnAssignRandom;
    public UnityEvent OnUndoMoves;
    public UnityEvent OnPauseGame;
    public UnityEvent OnContinueGame;

    public UnityEvent stamevent;
    private UnityAction stamaction;

    private void Awake()
    {
        
    }
    public void OnEventFired(string eventName)
    {
        StartCoroutine(eventName);
    }

    private IEnumerator NextTurn()
    {
        OnNextTurn?.Invoke();
        yield return null;
    }

    private IEnumerator EndGame()
    {
        OnEndGame?.Invoke();
        yield return null;
    }

    private IEnumerator SetCurrentPlayer()
    {
        OnSetCurrentPlayer?.Invoke();
        yield return null;
    }

    private IEnumerator RestartGame()
    {
        OnRestartGame?.Invoke();
        yield return null;
    }

    private IEnumerator AssignRandom()
    {
        OnAssignRandom?.Invoke();
        yield return null;
    }

    private IEnumerator UndoMoves()
    {
        OnUndoMoves?.Invoke();
        yield return null;
    }

    private IEnumerator PauseGame()
    {
        OnPauseGame?.Invoke();
        yield return null;
    }

    private IEnumerator ContinueGame()
    {
        OnContinueGame?.Invoke();
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
