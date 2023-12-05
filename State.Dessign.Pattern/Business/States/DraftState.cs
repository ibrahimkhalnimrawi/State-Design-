using State.Design.Pattern.Domain;

namespace State.Design.Pattern.Business.States;

public class DraftState : OrderState
{
    public override void Confirm(Order order)
    {
        order.State = new ConfirmedState();
        order.CreatedAt = DateTime.Now;
    }

    public override void Cancel(Order order)
    {
        order.State = new CanceledState();
        order.CanceledAt = DateTime.Now;
    }

}
