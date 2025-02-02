using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CC : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;

    public Transform cameraTransform;
    public float mouseSensitivity = 100.0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float cameraPitch = 0.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Bloque le curseur
    }

    void Update()
    {
        HandleMovement();
        HandleCameraRotation();
    }

    private void HandleMovement()
    {
        // Vérifier si le personnage est au sol
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Rester collé au sol
        }

        // Récupérer les entrées de mouvement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Appliquer le mouvement
        controller.Move(move * speed * Time.deltaTime);

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravité
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleCameraRotation()
    {
        // Récupérer les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Tourner le joueur horizontalement (Y-axis)
        transform.Rotate(Vector3.up * mouseX);

        // Ajuster l'angle de la caméra verticalement (X-axis)
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f); // Limiter l'angle vertical pour éviter de regarder trop haut/bas

        // Appliquer la rotation verticale uniquement à la caméra
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }
}