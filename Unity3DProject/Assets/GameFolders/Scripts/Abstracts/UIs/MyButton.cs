using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour
{
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        button.onClick.AddListener(HandleOnButtonClicked);
    }


    void OnDisable()
    {
        button.onClick.RemoveListener(HandleOnButtonClicked);
    }

    protected abstract void HandleOnButtonClicked();
}
