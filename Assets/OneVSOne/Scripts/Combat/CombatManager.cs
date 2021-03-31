using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    public Fighter[] fighters;
    private int fighterIndex;

    private bool isCombatActive;

    void Start()
    {
        LogPanel.Write("Battle initiated.");

        this.fighterIndex = 0;
        this.isCombatActive = true;
        StartCoroutine(this.CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        while (this.isCombatActive)
        {
            yield return new WaitForSeconds(2f);

            var currentTurn = this.fighters[this.fighterIndex];

            LogPanel.Write($"{currentTurn.idName} has the turn.");
            currentTurn.InitTurn();

            this.fighterIndex = (this.fighterIndex + 1) % this.fighters.Length;
        }
    }
}
