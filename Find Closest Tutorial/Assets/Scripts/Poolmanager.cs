using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Poolmanager : MonoBehaviour
{
    // Poolmanager singleton
    private static Poolmanager _instance;
    public static Poolmanager Instance

    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Poolmanager");
                go.AddComponent<Poolmanager>();
            }
            return _instance;
        }

    }
    void Awake()
    {
        _instance = this;
    }

    //Setting up poolable objects info

    [Header("Knights_red")]
    public GameObject r_KnightPrefab;
    public GameObject r_KnightContainer;
    public int r_KnightsToSpawn = 5;
    public List<GameObject> r_Knightlist = new List<GameObject>();


    [Header("Knights_blue")]
    public GameObject KnightPrefab;
    public GameObject KnightContainer;
    public int KnightsToSpawn = 5;
    public List<GameObject> Knightlist = new List<GameObject>();

    public List<GameObject> bluesTotal = new List<GameObject>();
    public List<GameObject> redstotal = new List<GameObject>();

    void Start()
    {
        //Settings objects ready for game
        for (int z = 0; z < KnightsToSpawn; z++)
        {
            GameObject knight = Instantiate(KnightPrefab, Vector3.zero, Quaternion.identity) as GameObject; //Create new unit
            knight.transform.parent = KnightContainer.transform; //put unit under its own container to make things more clear in editor
            knight.SetActive(false); //we unit unactive
            Knightlist.Add(knight); // add to list
            bluesTotal.Add(knight);
        }

        for (int i = 0; i < r_KnightsToSpawn; i++)
        {
            GameObject r_knight = Instantiate(r_KnightPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            r_knight.transform.parent = r_KnightContainer.transform;
            r_knight.SetActive(false);
            r_Knightlist.Add(r_knight);
            redstotal.Add(r_knight);
        }

    }
}
