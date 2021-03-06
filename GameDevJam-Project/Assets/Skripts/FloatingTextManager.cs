using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    public GameObject dialogBox;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText();
    }



    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
    FloatingText floatingText = GetFloatingText();

    floatingText.txt.text = msg;
    floatingText.txt.fontSize = fontSize;
    floatingText.txt.color = color;
    floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); //transfer wolrd space to screenspace so we can use it in the UI
    floatingText.motion = motion;
    floatingText.duration = duration;

        floatingText.Show();

        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);

        }
        else
        {
            dialogBox.SetActive(true);
        }
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(textContainer => !textContainer.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }
        return txt;
    }

    

}
