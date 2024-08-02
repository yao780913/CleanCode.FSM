namespace FSM.StatePattern;

public interface ITurnstileState
{
    void Coin (Turnstile t);
    void Pass (Turnstile t);
}

public class LockedTurnstileState : ITurnstileState
{
    public void Coin (Turnstile t)
    {
        t.SetUnlocked();
        t.Unlock();
    }

    public void Pass (Turnstile t)
    {
        t.Alarm();
    }
}

public class UnlockedTurnstileState : ITurnstileState
{
    public void Coin (Turnstile t)
    {
        t.ThankYou();
    }

    public void Pass (Turnstile t)
    {
        t.SetLocked();
        t.Lock();
    }
}