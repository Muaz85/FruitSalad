using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    bool isCutting = false;
    public GameObject baledtrilprefab;

    public float minCuttingvolictiy = .001f; 

    Vector2 privasPosition;
    GameObject currentBladeTrail;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circle2dcollider;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circle2dcollider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCutting();
        }
    }

    private void UpdateCutting()
    {
        Vector2 newposition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newposition;

        float velocity = (newposition - privasPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingvolictiy)
        {
            circle2dcollider.enabled = true;
        }
        else
        {
            circle2dcollider.enabled = false;
        }
        privasPosition = newposition;
    }

    private void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circle2dcollider.enabled = false;
    }

    private void StartCutting()
    {
        isCutting = true;
        currentBladeTrail =Instantiate(baledtrilprefab,transform);
        privasPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circle2dcollider.enabled = false;
    }
}
