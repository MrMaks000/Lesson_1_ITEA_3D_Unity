using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class JumpTimeDisplay : MonoBehaviour
{
    [SerializeField] private Jump jump;
    [SerializeField] private GameObject Number;
    [SerializeField] private int timeOfDelay = 4;

    private Text text;
    private int time;
    private bool isUpdateText = false;

    private void Start()
    {        
        Number.SetActive(false);
        text = Number.GetComponent<Text>();
        time = timeOfDelay;
    }

    private void Update()
    {
        if (isUpdateText == false)
        {
            isUpdateText = true;
            StartCoroutine(UpdateText(1f));
        }           
    }

    private IEnumerator UpdateText(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (jump.GetCanDoubleJump() == false)
        {
            Number.SetActive(false);
            time = timeOfDelay;
        }
        else
        {
            Number.SetActive(true);
            text.text = Convert.ToString(time);
            time--;

            if (time < 0)
            {
                time = 0;
            }
        }
        isUpdateText = false;
    }
}
