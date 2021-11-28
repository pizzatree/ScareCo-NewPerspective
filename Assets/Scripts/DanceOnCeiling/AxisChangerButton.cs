using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AxisChangerButton : MonoBehaviour
{
    private WorldRotationChanger worldRotationChanger;
    private TMP_Text             label;
    
    private void Start()
    {
        worldRotationChanger = FindObjectOfType<WorldRotationChanger>();

        if(!worldRotationChanger)
        {
            Debug.LogWarning("No world rotation changer");
            Destroy(gameObject);
            return;
        }

        label = transform.Find("Title").GetComponent<TMP_Text>();
    }

    public void ChangeAxis()
    {
        var letter = worldRotationChanger.ToggleAxis();

        label.text = $"{letter.ToString().ToUpper()} Axis";
    }
}
