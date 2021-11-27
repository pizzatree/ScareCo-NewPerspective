using UnityEngine;

public class RigSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject simulator, XR;

    [SerializeField] private bool _override = false;
    [SerializeField, Tooltip("Only works if override is true")]
    private RigType _rigOverride;

    private void Start()
    {
        var useSimulator = Application.isEditor;
        if(_override)
            useSimulator = _rigOverride == RigType.Simulator;

        simulator.SetActive(useSimulator);
        XR.SetActive(!useSimulator);
    }

    private enum RigType
    {
        Simulator,
        Headset
    }
}