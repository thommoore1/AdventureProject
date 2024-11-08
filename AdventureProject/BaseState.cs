namespace AdventureF24;

public class BaseState
{
    public StateType Type;
    private List<Action> methodsToCallOnActivate = new List<Action>();
    private List<Action> methodsToCallOnDeactivate = new List<Action>();
    public bool IsActive { get; private set; }

    public BaseState()
    {
        IsActive = false;
    }
    
    public BaseState(StateType type)
    {
        Type = type;
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
        foreach (Action action in methodsToCallOnActivate)
        {
            action.Invoke();
        }
    }

    public void Deactivate()
    {
        IsActive = false;
        foreach (Action action in methodsToCallOnDeactivate)
        {
            action.Invoke();
        }
    }

    public void AddToDeactivateCallList(Action action)
    {
        methodsToCallOnDeactivate.Add(action);
    }

    public void AddToActivateCallList(Action action)
    {
        methodsToCallOnActivate.Add(action);
    }
}