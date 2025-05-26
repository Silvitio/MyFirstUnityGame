using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;            // Цель слежения
    public Vector3 offset;              // Смещение камеры относительно player
    public float tiltAngle = 30f;       // Угол наклона камеры вниз

    private void LateUpdate() {
        Vector3 desiredPosition = player.position + offset;
        
        desiredPosition.y = player.position.y + offset.y - Mathf.Tan(Mathf.Deg2Rad * tiltAngle) * offset.z;
        
        transform.position = desiredPosition;

        transform.LookAt(player);
    }
}
