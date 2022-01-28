using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] private int nextLevel;
    [SerializeField] private LayerMask layerMask;

    private void Start() {}
    private void Update() {}
    private void FixedUpdate() {}
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision Enter");
        if (layerMask == (layerMask | (1 << other.gameObject.layer))) {
            Debug.Log("Layer Mask Collision");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
