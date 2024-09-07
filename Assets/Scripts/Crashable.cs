using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.DEATH))
        {
            //TODO: add call to player death function in player controller if it exists

            //spawn explosion particle
            Instantiate(particleEffect, gameObject.transform);
            GlobalEvents.PlayerDeath.invoke();
            
        }
    }
}
