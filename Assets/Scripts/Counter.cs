using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<float> TimeChanged;

    private int _beginningReport = 0;
    private bool _isActive = true;

    private void OnMouseDown()
    {
        if (_isActive)
        {
            _isActive = false;
            StopCoroutine(CountDown());
        }
        else
        {
            _isActive = true;
            StartCoroutine(CountDown());
        }          
    }

    private IEnumerator CountDown(float delay = 0.5f)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            _beginningReport++;
            TimeChanged?.Invoke(_beginningReport);
            yield return wait;
        }    
    }
}
