using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPushed;
    [SerializeField] private float      buttonThreshold = 0.2f;

    private Transform button;
    
    private bool    isActivated;
    private Vector3 buttonStartPos;
    
    private void Start()
    {
        button         = transform.Find("Button");
        buttonStartPos = button.localPosition;
    }
    
    private void Update()
    {
        var pos = button.localPosition;
        pos.z                = Mathf.Clamp(pos.z, buttonStartPos.z - buttonThreshold, buttonStartPos.z);
        button.localPosition = pos;

        var buttonActuated = Mathf.Abs(Vector3.Distance(buttonStartPos, pos)) > buttonThreshold * 0.5f;

        if(isActivated && buttonActuated)
            return;

        if(buttonActuated)
        {
            isActivated = true;
            OnPushed?.Invoke();
            return;
        }

        isActivated = false;
    }
}