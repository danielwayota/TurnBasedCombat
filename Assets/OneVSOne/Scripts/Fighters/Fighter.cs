using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public string idName;
    public StatusPanel statusPanel;

    public CombatManager combatManager;

    protected Stats stats;

    protected virtual void Start()
    {
        this.statusPanel.SetStats(this.idName, this.stats);
    }

    public void ModifyHealth(float amount)
    {
        this.stats.health = Mathf.Clamp(this.stats.health + amount, 0f, this.stats.maxHealth);
        this.statusPanel.SetHealth(this.stats.health, this.stats.maxHealth);
    }

    public abstract void InitTurn();
}
