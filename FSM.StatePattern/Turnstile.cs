using Shared;

namespace FSM.StatePattern;

public class Turnstile
{
    internal static ITurnstileState lockedState = new LockedTurnstileState();
    internal static ITurnstileState unlockedState = new UnlockedTurnstileState();
    
    public ITurnstileState state = lockedState;
    
    private readonly ITurnstileController _action;

    public Turnstile (ITurnstileController action)
    {
        _action = action;
    }

    public void Coin () => state.Coin(this);
    
    public void Pass () => state.Pass(this);
    public void SetLocked () => state = lockedState;
    public void SetUnlocked () => state = unlockedState;
    
    public bool IsUnlocked() =>  state == unlockedState;
    
    public bool IsLocked() => state == lockedState;
    
    internal void ThankYou () => _action.ThankYou();
    
    internal void Lock () => _action.Lock();
    
    internal void Unlock () => _action.Unlock();
    
    internal void Alarm () => _action.Alarm();
    
}