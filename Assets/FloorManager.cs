using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] FloorPrefabs;

    public void SpawnFloor()
    {
        int type = Random.Range(0, FloorPrefabs.Length);
        GameObject floor = Instantiate(FloorPrefabs[type], transform);
        Destroy(floor.GetComponent<BoxCollider2D>());
        floor.AddComponent<BoxCollider2D>();
        floor.transform.position = new Vector3(Random.Range(-8f,8f),-6f ,0f);
        floor.transform.localScale = new Vector3(Random.Range(1f,3f), 0.5f, 0f);

        
    }
}
