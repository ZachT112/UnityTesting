using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private LayerMask coinLayerMask;

    void Start() {}
    void Update() {}
    private void FixedUpdate() {
        if (Physics.CheckSphere(gameObject.transform.position, 0.1f, coinLayerMask)) {
            ScoreKeeper.instance++;
            ScoreKeeper.instance.Log();
            Destroy(gameObject);
        }
    }
}
