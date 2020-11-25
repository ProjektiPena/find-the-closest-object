using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    private static StatsManager _instance;
    public static StatsManager Instance

    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("StatsManager");
                go.AddComponent<StatsManager>();
            }
            return _instance;
        }

    }
    void Awake()
    {
        _instance = this;
    }


       public int redsDeads;
       public int bluesDeads;
       public Text bluesLeft;
       public Text redsLeft;

       private void Start()
       {

        Counter();
    }
       private void Update()
       {
        


        bluesLeft.text = "Blue units left: " + bluesDeads.ToString();
           redsLeft.text = "Red units left: " + redsDeads.ToString();
       }

    void Counter()
    {

        for (int i = 0; i < Poolmanager.Instance.redstotal.Count; i++)
        {

            if (Poolmanager.Instance.redstotal[i].GetComponent<KnightDamage>().isDead == false)
            {

                redsDeads++;
            }
        }

        for (int i = 0; i < Poolmanager.Instance.bluesTotal.Count; i++)
        {

            if (Poolmanager.Instance.bluesTotal[i].GetComponent<KnightDamage>().isDead == false)
            {

                bluesDeads++;
            }
        }

    }
       
}
