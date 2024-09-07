using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Collider box;
    public int cp_index;
    public LapTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<Collider>();
        box.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collision");
        if (other.gameObject == tracker.cart)
        {

            Debug.Log("Collision with Kart");
            tracker.checkpoints_hit[cp_index] = true;

            // We've hit all the checkpoints and are at the start, so it's a new lap
            if(tracker.checkpoints_hit.All(x => x) && cp_index == 0)
            {
                tracker.lap_count += 1;
                tracker.clearCheckpoints();
            }
        }
    }
}
