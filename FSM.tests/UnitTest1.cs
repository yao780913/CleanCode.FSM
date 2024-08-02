using Lab.FSM;
using Shared;

namespace FSM.tests;

public class TurnstileTest
{
    private Turnstile _turnstile;
    private TurnstileControllerSpoff _controllerSpoff;

    [SetUp]
    public void Setup ()
    {
        _controllerSpoff = new TurnstileControllerSpoff();
        _turnstile = new Turnstile(_controllerSpoff);
    }

    [Test]
    public void InitialConditions ()
    {
        Assert.AreEqual(State.Locked, _turnstile.state);
    }
    
    
}



internal class TurnstileControllerSpoff : ITurnstileController
{
    public bool LockCalled = false;
    public bool UnlockCalled = false;
    public bool AlarmCalled = false;
    public bool ThankYouCalled = false;

    public void Unlock () => LockCalled = true;
    public void Alarm () => AlarmCalled = true;
    public void ThankYou () => ThankYouCalled = true;
    public void Lock () => UnlockCalled = true;
}