using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTracker : MonoBehaviour
{
    public GameObject cart;
    public int lap_count = 0;
    public int max_lap_count = 3;

    public int num_checkpoints = 0;

    public float time = 0;

    public bool[] checkpoints_hit;

    // Start is called before the first frame update
    void Start()
    {   
        checkpoints_hit = new bool[num_checkpoints];
        clearCheckpoints();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }

    public void clearCheckpoints()
    {
        for (int i = 0; i < checkpoints_hit.Length; i++)
        {
            checkpoints_hit[i] = false;
        }
    }
}
