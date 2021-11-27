using System;
using TMPro;
using UnityEngine;

public class SwitchToSceneButton : MonoBehaviour
{
    public Scenes scene;

    private void OnValidate()
    {
        name = $"{scene.ToString()} button";
        transform.Find("Title").GetComponent<TMP_Text>().text = scene.ToString();
    }
}