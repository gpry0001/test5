using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform center;
    public Transform shotpoint;
    public GameObject bullets;
    public float radius = 0.7f;
    
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 dir = (mousePos - center.position).normalized;
        transform.position = center.position + dir * radius;
        transform.up = dir;

        Vector3 bulletdir = (mousePos - shotpoint.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        shotpoint.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            shot();
        }
    }

    public void shot()
    {
        GameObject newBullet = Instantiate(bullets, shotpoint.position, shotpoint.rotation);
    }


}
