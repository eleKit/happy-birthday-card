using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPool : MonoBehaviour
{
    public float min_pos = -5f;

    public float max_pos = 5f;

    public float delta_duration = 0.5f;

    public float fixed_starting_y = -5f;

    public GameObject[] balloons;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        instantiateBalloon();

    }

    // Update is called once per frame
    void Update()
    {
        if (time >= delta_duration)
        {
           instantiateBalloon();
           time = 0;
        }

        time += Time.deltaTime;

    }

    private void instantiateBalloon()
    {
        Instantiate(balloons[Random.Range(0, balloons.Length)],
            new Vector3(Random.Range(min_pos, max_pos + 0.5f), fixed_starting_y, 0f), Quaternion.identity);
    }
}
