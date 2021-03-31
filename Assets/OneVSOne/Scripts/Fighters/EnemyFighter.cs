using UnityEngine;

public class EnemyFighter : Fighter
{
    void Awake()
    {
        this.stats = new Stats(20, 50, 40, 30, 60);
    }

    public override void InitTurn()
    {

    }
}
