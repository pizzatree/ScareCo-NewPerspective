using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class WristMenuOpener : MonoBehaviour
{
    [Header("Dependencies")]
    [FormerlySerializedAs("leftHandAlias")]
    [SerializeField] private Transform handAlias;
    [SerializeField] private Transform headsetAlias;
    [SerializeField] private Transform menuRoot;

    [Header("Menu Physical Attributes")]
    [SerializeField] private Vector3   posOffsetFromHand   = Vector3.up;
    [SerializeField] private Vector3   eulerOffsetFromHand = new Vector3(0f, 90f, 0f);

    [Header("Menu Preferences")] 
    [SerializeField] private float openBuffer = 1f;
    [SerializeField] private float closeBuffer = 0.2f;
    [SerializeField] private float toggleSpeed = 0.2f;
    [SerializeField] private float minAngle    = 0f, maxAngle = 50f;
    
    private bool opened;
    private bool opening;

    private Coroutine currentCoroutine;

    private void OnValidate() => UpdateTransform();

    private void Start()
    {
        UpdateTransform();
        transform.SetParent(handAlias);

        SetMenuActive(false);
    }
    
    private void Update()
    {
        var angle    = GetAngle();
        var isValidAngle = IsValidAngle(angle);
        
        if(!opening && isValidAngle)
            SetMenuActive(true);
        
        if(opening && !isValidAngle)
            SetMenuActive(false);
    }

    private void SetMenuActive(bool active)
    {
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        opening = active;

        var nextScale = active ? Vector3.one : Vector3.zero;
        var buffer    = active ? openBuffer : closeBuffer;
        currentCoroutine = StartCoroutine(nameof(SetMenuScale), (nextScale, buffer));
    }

    private IEnumerator SetMenuScale((Vector3 newScale, float buffer) attribs)
    {
        yield return new WaitForSeconds(attribs.buffer);
        menuRoot.gameObject.SetActive(true);

        var oldScale = menuRoot.localScale;
        var t        = 0f;

        while(t <= 1f)
        {
            t += Time.deltaTime * toggleSpeed; 
            
            menuRoot.localScale =  Vector3.Lerp(oldScale, attribs.newScale, t);
            yield return null;
        }

        opened = attribs.newScale.sqrMagnitude > 0.1f;
        if(!opened)
            menuRoot.gameObject.SetActive(false);
    }


    private float GetAngle()
    {
        var tForward = transform.forward.normalized;
        var hForward = headsetAlias.forward.normalized;
        var hRight   = headsetAlias.right.normalized;

        return SignedAngleBetween(tForward, hForward, Vector3.Cross(hForward, hRight));
    }
    
    private bool IsValidAngle(float angle) => angle >= minAngle && angle <= maxAngle;

    // from https://stackoverflow.com/questions/19675676/calculating-actual-angle-between-two-vectors-in-unity3d
    float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n) 
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        float sign  = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        // angle in [-179,180]
        return angle * sign;
    }

    private void UpdateTransform()
    {
        if(!handAlias || !headsetAlias)
            return;

        var pos = handAlias.position + posOffsetFromHand;
        var rot = Quaternion.Euler(eulerOffsetFromHand) * handAlias.rotation;
        transform.SetPositionAndRotation(pos, rot);
    }
}