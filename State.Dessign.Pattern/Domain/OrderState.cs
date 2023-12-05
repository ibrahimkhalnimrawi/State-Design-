namespace State.Design.Pattern.Domain;

public abstract class OrderState
{
    public virtual void Confirm(Order order)
    {
        throw new InvalidOperationException("Not allowed to confirm");
    }

    public virtual void Process(Order order)
    {
        throw new InvalidOperationException("Not allowed to process");
    }

    public virtual void Cancel(Order order)
    {
        throw new InvalidOperationException("Not allowed to cancel");
    }

}
