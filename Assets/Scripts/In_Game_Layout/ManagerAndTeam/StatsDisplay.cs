using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    public GameObject managerAndTeam;

    public CharacterInfo[] managerStatsList;
    public CharacterInfo[] memberStatsList;

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

    public void DisplayCharacterStats(int managerInt, string nameOfTeammate)
    {
        CharacterInfo selectedChar;

        if (nameOfTeammate == "0")
        {
            selectedChar = managerStatsList[managerInt];
            //Debug.Log("confirmManagerInt is: " + managerInt);
        }
        else
        { 
            int confirmTeammateInt = 0;

            foreach (GameObject element in managerAndTeam.GetComponent<GetManagerAndTeam>().teamMemberList)
            {
                if (element.name == nameOfTeammate)
                {
                    confirmTeammateInt = System.Array.IndexOf(managerAndTeam.GetComponent<GetManagerAndTeam>().teamMemberList, element);
                    //Debug.Log("confirmTeammateInt is: " + confirmTeammateInt);
                }
            }

            selectedChar = memberStatsList[confirmTeammateInt];
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
