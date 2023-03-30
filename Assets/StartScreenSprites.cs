using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the behaviour of the enemy sprites in the start screen
public class StartScreenSprites : MonoBehaviour
{
    // Variables to control the amplitude, frequency, and speed of the motion
    public float amplitude = 1.0f;
    public float frequency = 1.0f;
    public float speed = 1.0f;

    // An array of targets to apply the motion to
    public Transform[] targets;

    // The time at which the motion started
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        // Record the start time
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the time elapsed since the motion started
        float time = Time.time - startTime;

        // Loop over all the targets and apply the motion to each one
        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 position = targets[i].position; // Get of the target's current position
            position.y = Mathf.Sin(time * speed + i * frequency) * amplitude; // Calculate the vertical displacement based on the sine of the time and the frequency
            targets[i].position = position; // Update the target's position
        }
    }
}
