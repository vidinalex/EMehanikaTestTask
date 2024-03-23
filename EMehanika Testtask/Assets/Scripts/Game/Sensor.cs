using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]
    private BuildingSettings settings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != settings.targetTag)
        {
            return;
        }

        for (int i = 0; i < settings.rewardAmount; i++)
        {
            Vector3 randOffset = new Vector3 (1, 1, 0) * Random.Range(-settings.maxOffset, settings.maxOffset);
            PoolManager.Default.Instantiate((int)settings.type, Camera.main.WorldToScreenPoint(transform.parent.position) + randOffset, true);
        }
    }
}
