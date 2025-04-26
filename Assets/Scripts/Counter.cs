using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private Coroutine _coroutine;
    private bool _isActive = true;
    private int _StartTime = 0;   

    public event Action<float> TimeChanged;

    private void OnMouseDown()
    {
        if (_isActive)
        {
            _isActive = false;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
        else
        {
            _isActive = true;
            _coroutine = StartCoroutine(CountDown());
        }          
    }

    private IEnumerator CountDown(float delay = 0.5f)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            _StartTime++;
            TimeChanged?.Invoke(_StartTime);           
            yield return wait;
        }    
    }
}
