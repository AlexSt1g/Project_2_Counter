using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField]private float _delay = 0.5f;
    
    private Coroutine _coroutine;
    private int _currentNumber = 0;    

    public event Action<int> Changed;    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ChangeCorutineStatus();
    }

    private void ChangeCorutineStatus()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(Count(_delay));
        }
    }    

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {            
            Changed?.Invoke(_currentNumber);
            
            _currentNumber++;
            yield return wait;            
        }
    }    
}
