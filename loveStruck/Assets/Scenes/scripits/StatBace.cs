using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBace : MonoBehaviour {

    public string Name;
    [Header ("Hp")]
    public float CurrentHP;
    public float MaxHP;
    [Header("social status")]
    [Range(1, 100)]
    public float curentsocialstatus;
    public static float MaxSocialStatus = 100;
    [Header("mental health")]
    [Range(1, 100)]
    public float curentMentalHealth;
    public static float MaxMentalHealth = 100;
    [Header("hands")]
    public Transform[] Hands = new Transform[2];
    public weaponBace WeponInHand;
    public Animation Ani;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("someting hit me");
        if (other.gameObject.tag == "weapons")
        {
             IsHit(other.gameObject.GetComponent<weaponBace>().AttackPower,other.gameObject.GetComponent<StatBace>().curentsocialstatus, other.gameObject.GetComponent<weaponBace>().embarrassedBoniss);
        }
    }
    public void spawnItem(GameObject ItemToSpawn,int handID)
    {
 
        var newitem = Instantiate(ItemToSpawn, Hands[handID].position, Hands[handID].localRotation);
        WeponInHand = newitem.gameObject.GetComponent<weaponBace>();
        newitem.transform.parent = Hands[handID].transform;
    }

    public void IsHit(float HPremove,float socialstats,float embarrassedB)
    {
        CurrentHP -= HPremove;
        if(MaxSocialStatus > curentsocialstatus && curentsocialstatus >1)
        {
            curentsocialstatus -= 0.5f;
            curentMentalHealth -= 0.1f+embarrassedB;
        }
        Debug.Log("hit");
    }

}
