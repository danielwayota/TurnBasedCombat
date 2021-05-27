using UnityEngine;

public class StatusModSkill : Skill
{
    [Header("Status mod skill")]
    public string message;

    protected StatusMod mod;

    protected override void OnRun()
    {
        if (this.mod == null)
        {
            this.mod = this.GetComponent<StatusMod>();
        }


        this.messages.Enqueue(this.message.Replace("{receiver}", this.receiver.idName));

        this.receiver.statusMods.Add(this.mod);
    }
}
