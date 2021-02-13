using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private TimerData _timerData;
    [SerializeField] private float _timer;

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
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _gameEvent.FireEvent("EndGame");
        }
    }
    public void ResetTimer()
    {
        _timer = _timerData.TimeForTurn;
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
