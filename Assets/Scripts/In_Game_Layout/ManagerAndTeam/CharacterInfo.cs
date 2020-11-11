using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewCharacterInfo", menuName = "CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    // Character Profile
    public Sprite characterImage;
    public new string name;
    public TextMeshProUGUI descriptionText;

    public int speed;
    public int quality;
    public int relationship;
    public int focus;
    public int creativity;

    public string trait;
    public string field;

    public TextMeshProUGUI leaderEffect;


    // Character Role(s) and Task(s)
    public string role;
    public TextMeshProUGUI roleDescription;

}
