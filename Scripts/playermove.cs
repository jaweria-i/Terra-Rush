using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 6f;
    public float horizontalSpeed = 3f;

    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    public GameObject playerObject; // For animations

    [SerializeField] bool isRunning;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool comingDown = false;

    void Update()
    {
        // Automatic forward movement
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);

        // Left-Right movement
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            if (transform.position.x > leftLimit)
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            if (transform.position.x < rightLimit)
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }

        // Jump input
        if ((Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed || Keyboard.current.spaceKey.isPressed)
            && !isJumping)
        {
            isJumping = true;
            playerObject.GetComponent<Animator>().Play("Jump");
            StartCoroutine(JumpSequence());
        }

        // Jump movement
        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * 5f * Time.deltaTime, Space.World);
            }
            else
            {
                transform.Translate(Vector3.down * 5f * Time.deltaTime, Space.World);
            }
        }

        // Distance tracking
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.35f);
        MasterInfo.distanceRun += 1;
        isRunning = false;
    }
}
