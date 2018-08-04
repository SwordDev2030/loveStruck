using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum interactionKind {Talking,Fighting,Scared,Bully}

public class NPCbace : StatBace {

    public interactionKind CurentInteraction;

   

    void OnCollisionEnter(Collision col)
    {
    
         if(col.gameObject.tag == "NPC"|| col.gameObject.tag == "Player")
        {
            bool TalkingToPLayer = col.gameObject.tag == "Player";
            StatBace Stat = col.gameObject.GetComponent<StatBace>();
            bool morePopula = Stat.curentsocialstatus < curentsocialstatus;
         }
 
    }

}
