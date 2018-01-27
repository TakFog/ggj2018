using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCard : MonoBehaviour {
    public Transform start, end;
    public float moveTotalTime, movingTime;
    public bool slideOut;

    public SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (renderer != null)
            renderer.enabled = false;
    }

    private void OnEnable()
    {
        if (renderer != null)  renderer.enabled = true;
        movingTime = moveTotalTime;
        transform.position = start.position;
    }

    private void Update()
    {
        if (movingTime <= 0)
        {
            this.enabled = false;
            if (renderer != null) renderer.enabled = false;
            transform.position = start.position;
            if (slideOut) EndOut(); else EndIn();
            return;
        }
        movingTime -= Time.deltaTime;
        transform.position = Vector3.Lerp(start.position, end.position, 1 - movingTime / moveTotalTime);
    }

    private void EndOut()
    {
        Hand.Instance.StartSlideIn();
    }

    private void EndIn()
    {
        Hand.Instance.EndSlideIn();
    }

}
