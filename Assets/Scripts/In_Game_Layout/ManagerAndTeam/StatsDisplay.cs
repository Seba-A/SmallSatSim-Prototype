using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    public GameObject managerAndTeam;
    public GameObject charInfoPanel;

    public Image charImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI keyStatsText;
    public TextMeshProUGUI descriptionText;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI qualityText;
    public TextMeshProUGUI relationshipText;
    public TextMeshProUGUI focusText;
    public TextMeshProUGUI creativityText;

    public TextMeshProUGUI traitText;
    public TextMeshProUGUI fieldText;

    public TextMeshProUGUI leaderEffectText;

    // Start is called before the first frame update
    void Start()
    {
        //DisplayCharacterStats();
    }

    public void DisplayCharacterStats(int managerInt, string nameOfTeammate)    // both managerInt & nameOfTeammate are obtained from PlayerPref
    {
        CharacterInfo selectedChar = null;

        if (nameOfTeammate == "nothing")    //Displaying manager stats

        {
            selectedChar = charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().managerInfo;
            //Debug.Log("confirmManagerInt is: " + managerInt + " from " + charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().managerInfo);
        }
        else    //Displaying member stats
        {
            foreach (CharacterInfo element in charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().teamMemberInfo)
            {
                //Debug.Log(element.ToString().Substring(0, 7) + " < IS THE SAME? > " + nameOfTeammate);
                if (element.ToString().Substring(0, 7) == nameOfTeammate.Substring(0, 7))
                {
                    selectedChar = element;
                }
            }
        }

        charImage.sprite = selectedChar.characterImage;
        nameText.text = selectedChar.name;
        keyStatsText.text = "Key Stats: S+" + selectedChar.speed.ToString() + " Q+" + selectedChar.quality.ToString() + "; " + selectedChar.trait.ToString();

        speedText.text = "Speed: " + selectedChar.speed.ToString();
        qualityText.text = "Quality: " + selectedChar.quality.ToString();
        relationshipText.text = "Relationship: " + selectedChar.relationship.ToString();
        focusText.text = "Focus: " + selectedChar.focus.ToString();
        creativityText.text = "Creativity: " + selectedChar.creativity.ToString();

        traitText.text = "Trait: " + selectedChar.trait.ToString();
        fieldText.text = "Field: " + selectedChar.field.ToString();

        descriptionText.text = selectedChar.charDescription.GetComponent<TMP_Text>().text;
        leaderEffectText.text = "Leader Effect: " + selectedChar.leaderEffect.GetComponent<TMP_Text>().text;
    }
}
