using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private bool x, y, z;
    [SerializeField] private float rotationsPerSecond;

    private int degreesPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        degreesPerSecond = (int) rotationsPerSecond * 360;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(x ? Time.deltaTime * degreesPerSecond : 0, y ? Time.deltaTime * degreesPerSecond : 0, z ? Time.deltaTime * degreesPerSecond : 0);
    }
}
