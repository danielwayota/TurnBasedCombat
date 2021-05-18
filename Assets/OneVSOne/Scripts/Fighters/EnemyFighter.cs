using UnityEngine;
using System.Collections;

public class EnemyFighter : Fighter
{
    void Awake()
    {
        this.stats = new Stats(20, 50, 40, 30, 60);
    }

    public override void InitTurn()
    {
        StartCoroutine(this.IA());
    }

    IEnumerator IA()
    {
        yield return new WaitForSeconds(1f);

        Skill skill = this.skills[Random.Range(0, this.skills.Length)];

        Fighter target = null;
        do {
            Fighter[] players = this.combatManager.GetOpposingTeam();
            target = players[Random.Range(0, players.Length)];
        } while (target.isAlive == false);

        skill.SetEmitterAndReceiver(
            this, target
        );

        this.combatManager.OnFighterSkill(skill);
    }
}
