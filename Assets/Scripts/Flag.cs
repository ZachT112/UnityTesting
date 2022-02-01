using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] private bool end;
    [SerializeField] private LayerMask layerMask;

    private void Start() {}
    private void Update() {}
    private void FixedUpdate() {}
    private void OnTriggerEnter(Collider other) {
        if (layerMask == (layerMask | (1 << other.gameObject.layer))) {
            if (end) {
                SceneManager.LoadScene(0);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
