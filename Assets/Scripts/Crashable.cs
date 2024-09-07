using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.DEATH))
        {
            //TODO: add call to player death function in player controller if it exists
            GlobalEvents.PlayerDeath.invoke();
            
        }
    }
}
