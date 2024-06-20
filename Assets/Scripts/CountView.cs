using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;        

    private void OnEnable()
    {
        _counter.Changed += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayCount;
    }

    private void DisplayCount()
    {
        _text.text = _counter.CurrentNumber.ToString("");
    }
}
