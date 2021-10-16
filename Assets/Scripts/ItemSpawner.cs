using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Transform  spawnPos;
    
    [SerializeField] private int   numItemsPerToken        = 3;
    [SerializeField] private float itemOutputVelocityScale = 1f;

    private void Start()
    {
        var currencyEater = GetComponentInChildren<CurrencyEater>();
        if(currencyEater)
            currencyEater.OnReceivedCurrency += StartDispensingItems;
    }

    public void StartDispensingItems()
    {
        StartCoroutine(nameof(DispenseItems));
    }

    private IEnumerator DispenseItems()
    {
        for(int i = 0; i < numItemsPerToken; ++i)
        {
            var item  = Instantiate(spawnPrefab, spawnPos.position, Quaternion.identity);
            var force = new Vector3(Random.value, Random.value, Random.value) * itemOutputVelocityScale;
            item.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            yield return new WaitForSeconds(1f);
        }
    }
}