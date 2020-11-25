using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : MonoBehaviour
{
    //Setting up spawner
    [Header("Reds")]
    public Transform spwanArea_reds; // area where knights will be spawned
    Vector3 center_r;
    Vector3 size_r;

    [Header("Blues")]
    public Transform spwanArea_blues;
    Vector3 center;
    Vector3 size;


    public void LaunchAttack() // Knight attack will be launched by clicking button
    {
        Blue_Knights(); // call the function
        Red_Knights();

    }

    void Red_Knights()
    {
        //
        center_r = spwanArea_reds.transform.position; // get center of spawning area
        size_r = spwanArea_reds.GetComponent<Collider>().bounds.size; // get area size of spawning area

        for (int r = 0; r < Poolmanager.Instance.r_Knightlist.Count; r++)
        {
            Vector3 randomposition = center_r + new Vector3(Random.Range(-size_r.x / 2, size_r.x / 2), Random.Range(-size_r.y / 2, size_r.y / 2), Random.Range(-size_r.z / 2, size_r.z / 2)); // get random position on spawning area

            if (Poolmanager.Instance.r_Knightlist[r].activeInHierarchy == false)
            {
                Poolmanager.Instance.r_Knightlist[r].SetActive(true); // set unit active
                Poolmanager.Instance.r_Knightlist[r].transform.position = randomposition; //set random position
                Poolmanager.Instance.r_Knightlist[r].transform.rotation = Quaternion.identity;

            }

        }
    }

    void Blue_Knights()
    {

        center = spwanArea_blues.transform.position;
        size = spwanArea_blues.GetComponent<Collider>().bounds.size;

        for (int z = 0; z < Poolmanager.Instance.Knightlist.Count; z++)
        {
            Vector3 randomposition = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

            if (Poolmanager.Instance.Knightlist[z].activeInHierarchy == false)
            {
                Poolmanager.Instance.Knightlist[z].SetActive(true);
                Poolmanager.Instance.Knightlist[z].transform.position = randomposition;
                Poolmanager.Instance.Knightlist[z].transform.rotation = Quaternion.identity;

            }

        }
    }
}
