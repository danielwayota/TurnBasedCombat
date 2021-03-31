using UnityEngine;

public class PlayerFighter : Fighter
{
    void Awake()
    {
        this.stats = new Stats(21, 60, 50, 45, 20);
    }

    public override void InitTurn()
    {

    }
}
