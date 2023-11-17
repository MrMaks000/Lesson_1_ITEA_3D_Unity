using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class JumpTimeDisplay : MonoBehaviour
{
    [SerializeField] private Jump jump;
    [SerializeField] private GameObject Number;

    private Text text;
    private int Time = 4;
    private bool isUpdateText = false;

    private void Start()
    {        
        Number.SetActive(false);
        text = Number.GetComponent<Text>();
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
            Time = 4;
        }
        else
        {
            Number.SetActive(true);
            text.text = Convert.ToString(Time);
            Time--;

            if (Time < 0)
            {
                Time = 0;
            }
        }
        isUpdateText = false;
    }
}
