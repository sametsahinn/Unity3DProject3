using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayWaveLevel : MonoBehaviour
{
    TMP_Text _levelText;

    void Awake()
    {
        _levelText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        GameManager.Instance.OnNextWave += HandleOnNextWave;
    }

    void OnDisable()
    {
        GameManager.Instance.OnNextWave -= HandleOnNextWave;
    }

    void HandleOnNextWave(int levelValue)
    {
        _levelText.text = levelValue.ToString();
    }
}
