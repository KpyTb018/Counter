using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.TimeChanged += DisplayTime;
    }

    private void OnDisable()
    {
        _counter.TimeChanged -= DisplayTime;
    }

    private void DisplayTime(float count)
    {
        _text.text = count.ToString("");
    }

}
