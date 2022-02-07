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
    private bool isSuperJump;
    private bool isSuperSpeed;
    private bool isGrounded;
    private float horizontalAxis;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
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

        isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.01f, groundCheckLayerMask);
        if (isGrounded) {
            string tag = Physics.OverlapSphere(groundCheckTransform.position, 0.01f, groundCheckLayerMask)[0].gameObject.tag;
            isSuperJump = (tag == "Bouncy");
            isSuperSpeed = (tag == "Speedy");
        }
        

        if (isJumpPressed) {
            if (isGrounded) {
                playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
                if (isSuperJump) {
                    playerRigidbody.AddForce(Vector3.up * playerJumpHeight * 1.5f, ForceMode.VelocityChange);
                } else {
                    playerRigidbody.AddForce(Vector3.up * playerJumpHeight, ForceMode.VelocityChange);
                }
            }
            isJumpPressed = false;
        }

        if (horizontalAxis != 0f) {
            if (isSuperSpeed) {
                playerRigidbody.velocity = new Vector3(horizontalAxis * playerSpeed * 2f, playerRigidbody.velocity.y, 0);
            } else {
                playerRigidbody.velocity = new Vector3(horizontalAxis * playerSpeed, playerRigidbody.velocity.y, 0);
            }
        } else if (isGrounded) {
            playerRigidbody.velocity = Vector3.zero;
        }
    }
}
