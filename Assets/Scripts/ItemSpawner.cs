using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemSpawner : MonoBehaviour
{
    [FormerlySerializedAs("beanPrefab")] [SerializeField]
    private GameObject spawnPrefab;
    [FormerlySerializedAs("beanSpawnPos")] [SerializeField]
    private Transform spawnPos;
    [FormerlySerializedAs("numBeansPerQuarter")] [SerializeField]
    private int numItemsPerToken = 3;

    [SerializeField] private float itemOutputVelocityScale = 1f;

    private void Start()
    {
        GetComponentInChildren<CurrencyEater>().OnReceivedCurrency += HandleReceivedCurrency;
    }

    private void HandleReceivedCurrency()
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