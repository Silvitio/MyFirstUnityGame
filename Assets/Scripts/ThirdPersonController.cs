using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2000f;
    public Transform cameraPivot; // точка, вокруг которой крутится камера (обычно объект-пустышка над игроком)
    public Transform cameraTransform; // сама камера

    private float xRotation = 0f; // угол по вертикали (наклон камеры)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // зафиксировать курсор по центру
    }

    void Update()
    {
        // Получаем движение по WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Направление движения относительно поворота камеры по горизонтали
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 moveVelocity = move.normalized * moveSpeed;

        // Передвижение через Rigidbody (FixedUpdate)
        MovePlayer(moveVelocity);

        // Поворот мышью камеры
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Вращаем игрока по горизонтали
        transform.Rotate(Vector3.up * mouseX);

        // Вращаем камеру по вертикали с ограничением угла
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Камера позиционируется в Update — смотри следующий шаг
    }

    private Vector3 velocity;

    void MovePlayer(Vector3 moveVelocity)
    {
        velocity = moveVelocity;
    }

    void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
