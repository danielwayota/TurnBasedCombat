using UnityEngine;

public class PlayerFighter : Fighter
{
    [Header("UI")]
    public PlayerSkillPanel skillPanel;
    public EnemiesPanel enemiesPanel;

    private Skill skillToBeExecuted;

    void Awake()
    {
        this.stats = new Stats(21, 60, 50, 45, 20);
    }

    public override void InitTurn()
    {
        this.skillPanel.ShowForPlayer(this);

        for (int i = 0; i < this.skills.Length; i++)
        {
            this.skillPanel.ConfigureButton(i, this.skills[i].skillName);
        }
    }

    /// ================================================
    /// <summary>
    /// Se llama desde EnemiesPanel.
    /// </summary>
    /// <param name="index"></param>
    public void ExecuteSkill(int index)
    {
        this.skillToBeExecuted = this.skills[index];

        if (this.skillToBeExecuted.selfInflicted)
        {
            this.skillToBeExecuted.SetEmitterAndReceiver(this, this);
            this.combatManager.OnFighterSkill(this.skillToBeExecuted);
            this.skillPanel.Hide();
        }
        else
        {
            Fighter[] enemies = this.combatManager.GetOpposingTeam();
            this.enemiesPanel.Show(this, enemies);
        }
    }

    public void SetTargetAndAttack(Fighter enemyFigther)
    {
        this.skillToBeExecuted.SetEmitterAndReceiver(this, enemyFigther);

        this.combatManager.OnFighterSkill(this.skillToBeExecuted);

        this.skillPanel.Hide();
        this.enemiesPanel.Hide();
    }
}
