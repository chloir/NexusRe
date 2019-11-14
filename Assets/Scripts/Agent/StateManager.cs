using UnityEngine;

public class StateManager : MonoBehaviour
{
    private State _initialState;
    private State _currentState;
    private State _nextState;
    private bool _changeState = false;

    public void SetInitialState(State state) => _initialState = state;

    protected void Start()
    {
        _initialState.OnStateEnter();
        _currentState = _initialState;
    }

    protected void Update()
    {
        if (_changeState)
        {
            _currentState.OnStateExit();    // stateを抜ける処理
            _currentState = _nextState;    // state変更処理
            _currentState.OnStateEnter();    // stateの初期化
            _changeState = false;
        }
    }

    public void ChangeState(State next)
    {
        _nextState = next;
        _changeState = true;
    }
}
