using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer DragLineRenderer;
    RedPlayer bird;

    // Start is called before the first frame update
    void Start()
    {
        DragLineRenderer = GetComponent<LineRenderer>();
        bird = FindObjectOfType<RedPlayer>();
        Vector3 line = new Vector3(bird.transform.position.x, bird.transform.position.y, -0.1f);
        
        DragLineRenderer.SetPosition(0, line );
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.IsDragging)
        {
            DragLineRenderer.enabled = true;
            DragLineRenderer.SetPosition(1, bird.transform.position);
        }
        else
        {
            DragLineRenderer.enabled = false;
        }
    }
}
