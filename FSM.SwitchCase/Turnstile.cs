using Shared;

public class Turnstile
{
    public State state = State.Locked;
    
    private readonly ITurnstileController _controller;
    
    public Turnstile (ITurnstileController action)
    {
        _controller = action;
    }

    public void HandleEvent (Event e)
    {
        switch (state)
        {
            case State.Locked:
                switch (e)
                {
                    case Event.Coin:
                        state = State.Unlocked;
                        _controller.Unlock();
                        break;
                    case Event.Pass:
                        _controller.Alarm();
                        break;
                }
                break;
            
            case State.Unlocked:
                switch (e)
                {
                    case Event.Coin:
                        _controller.ThankYou();
                        break;
                    case Event.Pass:
                        state = State.Locked;
                        _controller.Lock();
                        break;
                }
                break;
        }
    }
}