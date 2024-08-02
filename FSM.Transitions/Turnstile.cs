using Shared;

public class Turnstile
{
    public State state = State.Locked;
    private readonly List<Transition> _transitions = [];
        
    public Turnstile (ITurnstileController controller)
    {
        var unlock = controller.Unlock;
        var alarm = controller.Alarm;
        var thankYou = controller.ThankYou;
        var lockAction = controller.Lock;
        
        AddTransition(State.Locked, Event.Coin, State.Unlocked, unlock);
        AddTransition(State.Locked, Event.Pass, State.Locked, alarm);
        AddTransition(State.Unlocked, Event.Coin, State.Unlocked, thankYou);
        AddTransition(State.Unlocked, Event.Pass, State.Locked, lockAction);
    }

    public void HandleEvent (Event e)
    {
        foreach (var transition in _transitions
                     .Where(transition => state == transition.StartState 
                                          && e == transition.Trigger))
        {
            state = transition.EndState;
            transition.Action();
        }
    }

    private void AddTransition (State start, Event e, State end, Action action)
    {
        _transitions.Add(new Transition(start, e, end, action));
    }
    
    /// <summary>
    /// 遷移表
    /// </summary>
    private class Transition
    {
        public State StartState { get; }
        public Event Trigger { get; }
        public State EndState { get; }
        public Action Action { get; }

        public Transition (State startState, Event trigger, State endState, Action action)
        {
            StartState = startState;
            Trigger = trigger;
            EndState = endState;
            Action = action;
        }
    }
}