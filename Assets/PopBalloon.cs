using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PopBalloon : MonoBehaviour
{
    private Transform me_transform;

    public float delta_movement = 0.2f;

    public int ponts_value = 10;

    public float max_y_to_destroy = 10f;

    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        me_transform = this.GetComponent<Transform>();
        manager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        me_transform.position += new Vector3(0, delta_movement, 0);
        if (me_transform.position.y >= max_y_to_destroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        manager.AddPoints(ponts_value);
    }
}
