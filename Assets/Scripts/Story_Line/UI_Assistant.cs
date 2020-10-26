using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UI_Assistant : MonoBehaviour
{
    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        int i = 0; //just added
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();

        transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
        {

            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                //Currently active text writer
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[]
                {
                    "1) Hakuna Matata!",
                    "2) What a wonderful phrase",
                    "3) in a Galaxy far far away",
                    "4) Ain't no passing craze",
                    "5) shrek lives",
                };

                //just added
                if (i < messageArray.Length)
                {
                    string message = messageArray[i];
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
                    i++;
                }
                else
                {
                    SceneManager.LoadScene("Character_Selection");
                }

                //this is no longer needed but is left here just because
                //string message = messageArray[Random.Range(0, messageArray.Length)];
                //textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
            }
        };
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, "Hakuna Matata! What a wonderful phrase Hakuna Matata! Ain't no passing craze", .1f, true);
    }
}
