using UnityEngine;

public class HealthModStatusCondition : StatusCondition
{
    [Header("Health mod")]
    public float percentage;

    public override bool OnApply()
    {
        Stats rStats = receiver.GetCurrentStats();

        this.receiver.ModifyHealth(rStats.maxHealth * this.percentage);

        this.messages.Enqueue(this.applyMessage.Replace("{receiver}", this.receiver.idName));

        return true;
    }

    public override bool BlocksTurn() => false;
}
