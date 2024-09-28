using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnScript : MonoBehaviour
{
    public GameObject LevelPrefab;
    public GameObject LastModel;
    public GameObject SpawnedModel;

    public List<GameObject> tablos = new List<GameObject>();

    void Start()
    {
    }

    void AddChild()
    {
         Transform tablosTransform = LastModel.transform.Find("tablos");
        if (tablosTransform != null)
        {
            // 'tablos' GameObject'inin altındaki çocukları listeye ekle
            foreach (Transform child in tablosTransform)
            {
                tablos.Add(child.gameObject);
            }
        }
    }

    public void Spawn()
    {
        SpawnedModel = LastModel;

        Vector3 lastpos = LastModel.transform.position + new Vector3(0, 0, 16);
        LastModel = Instantiate(LevelPrefab, lastpos, Quaternion.identity);

        tablos.Clear();
        AddChild();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Levels"))
        {
            Debug.Log("LevelSpawned");
            Spawn();

            if (SpawnedModel != null)
            {
                Transform levelCollTransform = SpawnedModel.transform.Find("LevelColl");
                if (levelCollTransform != null)
                {
                    levelCollTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}
