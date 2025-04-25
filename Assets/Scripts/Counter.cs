using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _counter = 0;
    private bool _isActive = false;  

    private void OnMouseDown()
    {
        if (_isActive)
            _isActive = false;
        else _isActive = true;

        StartCoroutine(CountDown());
    }
 
    private IEnumerator CountDown(float delay = 0.5f)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            _counter++;
            DisplayCountdown(_counter);
            yield return wait;
        }    
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
