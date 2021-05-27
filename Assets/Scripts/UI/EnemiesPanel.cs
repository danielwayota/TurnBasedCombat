using UnityEngine;
using UnityEngine.UI;

public class EnemiesPanel : MonoBehaviour
{
    public GameObject[] btns;
    public Text[] btnLabels;

    private PlayerFighter targetFigther;

    private Fighter[] targets;

    void Awake()
    {
        this.Hide();

        this.targets = new Fighter[this.btns.Length];
    }

    public void ConfigureButton(Fighter fighter, int index)
    {
        this.btns[index].SetActive(true);
        this.btnLabels[index].text = fighter.idName;

        this.targets[index] = fighter;
    }

    public void OnTargetButtonClick(int index)
    {
        Fighter enemy = this.targets[index];

        this.targetFigther.SetTargetAndAttack(enemy);
    }

    public void Show(PlayerFighter playerTarget, Fighter[] enemies)
    {
        this.gameObject.SetActive(true);

        this.targetFigther = playerTarget;

        int btnIndex = 0;
        foreach (var enemy in enemies)
        {
            if (enemy.isAlive)
            {
                this.ConfigureButton(enemy, btnIndex);
                btnIndex ++;
            }
        }
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);

        foreach (var btn in this.btns)
        {
            btn.SetActive(false);
        }
    }
}
