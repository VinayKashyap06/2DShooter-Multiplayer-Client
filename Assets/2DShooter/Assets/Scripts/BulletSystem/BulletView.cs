using UnityEngine;
using System.Collections;
using Commons;
using System;

public class BulletView : MonoBehaviour
{
    private float speed;
    private float direction;

    private void Start()
    {        
        direction = this.transform.position.x > 0 ? -1f : 1f;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(direction,0,0)*Time.deltaTime*speed);
    }
}
