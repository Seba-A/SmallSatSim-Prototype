using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    public CharacterInfo character;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayCharacterStats()
    {
        charImage.sprite = character.characterImage;
        nameText.text = character.name;
        keyStatsText.text = "Key Stats: S+" + character.speed.ToString() + " Q+" + character.quality.ToString() + "; " + character.trait.ToString();

        speedText.text = "Speed: " + character.speed.ToString();
        qualityText.text = "Quality: " + character.quality.ToString();
        relationshipText.text = "Relationship: " + character.relationship.ToString();
        focusText.text = "Focus: " + character.focus.ToString();
        creativityText.text = "Creativity: " + character.creativity.ToString();

        traitText.text = "Trait: " + character.trait.ToString();
        fieldText.text = "Field: " + character.field.ToString();

        descriptionText.text = character.charDescription.GetComponent<TMP_Text>().text;
        leaderEffectText.text = "Leader Effect: " + character.leaderEffect.GetComponent<TMP_Text>().text;
    }
    
}
