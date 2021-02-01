using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void LoadScene()
    {
        button.interactable = false;
        StartCoroutine(SceneControl.current.LoadScene("Map"));
        button.interactable = true;
    }

    public void UnloadScene()
    {
        button.interactable = false;
        StartCoroutine(SceneControl.current.UnloadAllScene());
        button.interactable = true;
    }

}
