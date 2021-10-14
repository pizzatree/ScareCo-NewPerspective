using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanMachine : MonoBehaviour
{
    [SerializeField] private GameObject bean;
    [SerializeField] private Transform  beanSpawnPos;
    [SerializeField] private int        numBeansPerQuarter = 3;
    
    private void Start()
    {
        GetComponentInChildren<QuarterEater>().OnReceivedQuarter += HandleReceivedQuarter;
    }

    private void HandleReceivedQuarter()
    {
        StartCoroutine(nameof(DispenseBeans));
    }

    private IEnumerator DispenseBeans()
    {
        for(int i = 0; i < numBeansPerQuarter; ++i)
        {
            Instantiate(bean, beanSpawnPos.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}