using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private AudioClip crashSfx;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.DEATH))
        {

            //spawn explosion particle
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.identity);
            //TODO: figure out if 100 works
            GlobalReferences.SFXMANAGER.PlaySoundFXClip(crashSfx, gameObject.transform, 100);
            //TODO: add call to player death function in player controller if it exists
            gameObject.GetComponent<CarController>().die();
            GlobalEvents.PlayerDeath.invoke();
            
        }
    }
}
