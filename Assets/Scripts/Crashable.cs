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
            //TODO: add call to player death function in player controller if it exists

            //spawn explosion particle
            Instantiate(particleEffect, gameObject.transform);
            //TODO: figure out if 100 works
            GlobalReferences.SFXMANAGER.PlaySoundFXClip(crashSfx, gameObject.transform, 100);
            GlobalEvents.PlayerDeath.invoke();
            
        }
    }
}
