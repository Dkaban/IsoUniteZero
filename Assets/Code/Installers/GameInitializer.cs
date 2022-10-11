using Zenject;

public class GameInitializer : IInitializable
{
    private readonly SignalBus _signalBus;

    public GameInitializer(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        //TODO: Initialization signals
    }
}
