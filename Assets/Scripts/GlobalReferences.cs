using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    private static SFXManager sfxManager;
   public static SFXManager SFXMANAGER {  get { return sfxManager; } set { sfxManager = value; } }

}
