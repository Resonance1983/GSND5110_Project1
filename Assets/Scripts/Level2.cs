using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics{


[DisallowMultipleComponent]
public class Level2 : MonoBehaviour
{
    public enum MechanicType
    {
        Transport,
        Appear,
        Disappear,
        DisapperSeveralTime,
    }

    [SerializeField]
    private MechanicType mechanicType;
    public GameObject player;
    private int tryingCount = 0;
    
    void OnTriggerEnter2D(Collider2D collider){
        if(mechanicType == MechanicType.Transport){
            GameObject transportPoint = GameObject.Find("TransportPoint");
            player.transform.position = transportPoint.transform.position;
        }else if(mechanicType == MechanicType.Appear){
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null){
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }else if(mechanicType == MechanicType.Disappear){
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null){
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }else if(mechanicType == MechanicType.DisapperSeveralTime){
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null){
                tryingCount+=1;
                if(tryingCount>=3){
                    gameObject.SetActive(false);
                }
            }
        }
    }
    


}

}