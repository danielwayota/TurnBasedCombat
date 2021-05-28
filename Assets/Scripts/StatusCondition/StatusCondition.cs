using UnityEngine;
using System.Collections.Generic;

public abstract class StatusCondition : MonoBehaviour
{
    [Header("Base Status Condition")]
    public GameObject effectPrfb;
    public float animationDuration;

    public string receptionMessage;
    public string applyMessage;
    public string expireMessage;

    public int turnDuration;

    public bool hasExpired { get { return this.turnDuration <= 0; } }

    protected Queue<string> messages;
    protected Fighter receiver;

    public void Awake()
    {
        this.messages = new Queue<string>();
    }

    public void SetReceiver(Fighter recv)
    {
        this.receiver = recv;
    }

    private void Animate()
    {
        var go = Instantiate(this.effectPrfb, this.receiver.transform.position, Quaternion.identity);
        Destroy(go, this.animationDuration);
    }

    public void Apply()
    {
        if (this.receiver == null)
        {
            throw new System.InvalidOperationException("StatusCondition needs a receiver");
        }

        if (this.OnApply())
        {
            this.Animate();
        }

        turnDuration--;

        if (this.hasExpired)
        {
            this.messages.Enqueue(this.expireMessage.Replace("{receiver}", this.receiver.idName));
        }
    }

    public string GetNextMessage()
    {
        if (this.messages.Count != 0)
            return this.messages.Dequeue();
        else
            return null;
    }

    public string GetReceptionMessage()
    {
        return this.receptionMessage.Replace("{receiver}", this.receiver.idName);
    }

    public abstract bool OnApply();
    public abstract bool BlocksTurn();
}