using FluentAssertions;
using Shared;

namespace FSM.tests;

public class TurnstileTests
{
    private Turnstile turnstile;
    private TurnstileControllerSpoff controllerSpoff;

    [SetUp]
    public void Setup ()
    {
        controllerSpoff = new TurnstileControllerSpoff();
        turnstile = new Turnstile(controllerSpoff);
    }

    [Test]
    public void InitialConditions ()
    {
        turnstile.state.Should().Be(State.Locked);
    }

    [Test]
    public void CoinInLockedState ()
    {
        turnstile.state = State.Locked;
        turnstile.HandleEvent(Event.Coin);

        turnstile.state.Should().Be(State.Unlocked);
        controllerSpoff.UnlockCalled.Should().BeTrue();
    }
    
    [Test]
    public void CoinInUnlockedState ()
    {
        turnstile.state = State.Unlocked;
        turnstile.HandleEvent(Event.Coin);

        turnstile.state.Should().Be(State.Unlocked);
        controllerSpoff.ThankYouCalled.Should().BeTrue();
    }
    
    [Test]
    public void PassInLockedState ()
    {
        turnstile.state = State.Locked;
        turnstile.HandleEvent(Event.Pass);

        turnstile.state.Should().Be(State.Locked);
        controllerSpoff.AlarmCalled.Should().BeTrue();
    }
    
    [Test]
    public void PassInUnlockedState ()
    {
        turnstile.state = State.Unlocked;
        turnstile.HandleEvent(Event.Pass);

        turnstile.state.Should().Be(State.Locked);
        controllerSpoff.LockCalled.Should().BeTrue();
    }
}



internal class TurnstileControllerSpoff : ITurnstileController
{
    public bool LockCalled = false;
    public bool UnlockCalled = false;
    public bool AlarmCalled = false;
    public bool ThankYouCalled = false;

    public void Unlock () => UnlockCalled = true;
    public void Alarm () => AlarmCalled = true;
    public void ThankYou () => ThankYouCalled = true;
    public void Lock () => LockCalled = true;
}