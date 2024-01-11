namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq;

public class ScopedHolder
{
    private readonly List<object?> _states = new();

    public void AddState(object state)
    {
        _states.Add(state);
    }

    public List<object?> GetStates() => _states.ToList();
}