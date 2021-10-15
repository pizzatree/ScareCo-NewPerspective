using UnityEngine;

public class RigSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject simulator, XR;
    private void Start()
    {
        simulator.SetActive(Application.isEditor);
        XR.SetActive(!Application.isEditor);
    }
}
