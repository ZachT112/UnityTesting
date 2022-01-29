using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private int respawnSceneIndex;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpHeight;
    [SerializeField] private int playerDeathAltitudeBottom;

    private Rigidbody playerRigidbody;
    private bool isJumpPressed;
    private bool isGrounded;
    private float horizontalAxis;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        isJumpPressed = false;
    }
    void Update() {
        isJumpPressed = isJumpPressed ? true : Input.GetAxis("Jump") > 0f;
        horizontalAxis = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate() {
        if (transform.position.y < playerDeathAltitudeBottom) {
            ScoreKeeper.instance.SetScore(0);
            SceneManager.LoadScene(respawnSceneIndex);
        }

        isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.001f, groundCheckLayerMask);

        if (isJumpPressed) {
            if (isGrounded) {
                playerRigidbody.AddForce(Vector3.up * playerJumpHeight, ForceMode.VelocityChange);
            }
            isJumpPressed = false;
        }

        if (horizontalAxis != 0f) {
            playerRigidbody.velocity = new Vector3(horizontalAxis * playerSpeed, playerRigidbody.velocity.y, 0);
        } else if (isGrounded) {
            playerRigidbody.velocity = Vector3.zero;
        }
    }
}
