using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreMadeLevelSpawn : MonoBehaviour
{
    public List<GameObject> premadelevels = new List<GameObject>();
    public GameObject LastModel;
    public GameObject SpawnedModel;

    void Start()
    {
        if (premadelevels.Count > 0)
        {
            LastModel = premadelevels[0];
        }
    }

    public void Spawn()
    {
        if (LastModel != null)
        {
            Transform levelCollTransform = LastModel.transform.Find("LevelColl");
            if (levelCollTransform != null)
            {
                levelCollTransform.gameObject.SetActive(false);
            }
        }

        int randomIndex = Random.Range(0, premadelevels.Count);
        Vector3 lastpos = LastModel.transform.position + new Vector3(0, 0, 16);
        SpawnedModel = Instantiate(premadelevels[randomIndex], lastpos, Quaternion.identity);
        LastModel = SpawnedModel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TLevel") || other.gameObject.CompareTag("FLevel"))
        {
            Debug.Log("LevelSpawned");
            Spawn();
        }
    }
}
