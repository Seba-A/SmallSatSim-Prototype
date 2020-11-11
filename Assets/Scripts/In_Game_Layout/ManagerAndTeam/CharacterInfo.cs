using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Relevant tutorial: https://www.youtube.com/watch?v=aPXvoWVabPY
 */

[CreateAssetMenu(fileName = "NewCharacterInfo", menuName = "CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    // Character Profile
    public Sprite characterImage;
    public new string name;
    public TextMeshProUGUI charDescription;

    public int speed;
    public int quality;
    public int relationship;
    public int focus;
    public int creativity;

    public string trait;
    public string field;

    public TextMeshProUGUI leaderEffect;


    // Character Role(s)
    public string role;
    public TextMeshProUGUI roleDescription;

    public void RoleEffects()
    {

    }


    // Character Task(s)
    public TextMeshProUGUI[] assignedTask = new TextMeshProUGUI[5];
}
