using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;          // Velocidade de movimento do avião
    public float rotationSpeed = 100.0f;     // Velocidade de rotação do avião

    void Update()
    {
        // Lê a entrada do teclado para movimento e rotação
        float moveInput = Input.GetAxis("Vertical");   // W/S ou Up/Down
        float rotateInput = Input.GetAxis("Horizontal"); // A/D ou Left/Right

        // Move o avião para frente ou para trás
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Rotaciona o avião à esquerda ou à direita
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }
}