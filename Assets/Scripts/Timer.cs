using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private TimerData _timerData;

    private bool _gamePaused = false;

    private void Start()
    {
        ResetTimer();
    }
    private void Update()
    {
        if (_gamePaused == false)
            RunTimer();
    }

    private void RunTimer()
    {
        _timerData.Timer -= Time.deltaTime;
        if (_timerData.Timer <= 0)
        {
            _gameEvent.FireEvent("EndGame");
        }
    }
    public void ResetTimer()
    {
        _timerData.Timer = _timerData.TimeForTurn;
    }

    public void PauseTimer()
    {
        _gamePaused = true;
    }   

    public void ContinueTimer()
    {
        _gamePaused = false;
    }
}
