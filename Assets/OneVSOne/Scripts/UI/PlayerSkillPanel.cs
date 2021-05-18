using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillPanel : MonoBehaviour
{
    public GameObject[] skillButtons;
    public Text[] skillButtonLabels;

    private PlayerFighter targetFigther;

    void Awake()
    {
        this.Hide();
    }

    public void ConfigureButton(int index, string skillName)
    {
        this.skillButtons[index].SetActive(true);
        this.skillButtonLabels[index].text = skillName;
    }

    public void OnSkillButtonClick(int index)
    {
        this.targetFigther.ExecuteSkill(index);
    }

    public void ShowForPlayer(PlayerFighter newTarget)
    {
        this.gameObject.SetActive(true);

        this.targetFigther = newTarget;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);

        foreach (var btn in this.skillButtons)
        {
            btn.SetActive(false);
        }
    }


}
