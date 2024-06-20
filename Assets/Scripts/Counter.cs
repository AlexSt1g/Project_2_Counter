using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField]private float _delay = 0.5f;
    
    private Coroutine _coroutine;

    public int CurrentNumber { get; private set; }

    public event Action Changed;

    private void Start()
    {
        CurrentNumber = 0;            
    }

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
            Changed?.Invoke();

            CurrentNumber++;
            yield return wait;            
        }
    }    
}
