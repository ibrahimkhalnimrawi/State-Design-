using State.Design.Pattern.Domain;

namespace State.Design.Pattern.Business.States;

public class ConfirmedState : OrderState
{
    public override void Process(Order order)
    {
        order.State = new ProcessState();
        order.ProcessedAt = DateTime.Now;
    }

    public override void Cancel(Order order)
    {
        order.State = new CanceledState();
        order.CanceledAt = DateTime.Now;
    }
}
