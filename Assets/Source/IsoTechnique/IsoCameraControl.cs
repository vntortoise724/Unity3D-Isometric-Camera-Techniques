using UnityEngine;

namespace Study.IsoCamera.Control
{
    public class IsoCameraControl : MonoBehaviour
    {
        private Camera isoCamera;

        private float yRotation = 45f;
        private readonly float rotationSpeed = 5f;
        private Quaternion targetRotation;

        [SerializeField] private float mouseScrollSpeed = 2f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            isoCamera = gameObject.GetComponentInChildren<Camera>();

            targetRotation = Quaternion.Euler(30f, yRotation, 0f);
            transform.rotation = targetRotation;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            float scroll = Input.mouseScrollDelta.y * mouseScrollSpeed * Time.deltaTime;
            float zoom = 0.5f * mouseScrollSpeed * Time.deltaTime;

            isoCamera.orthographicSize = Mathf.Clamp(isoCamera.orthographicSize - scroll, 1.5f, 5.5f);

            if (Input.GetKey(KeyCode.Z))
                isoCamera.orthographicSize = Mathf.Clamp(isoCamera.orthographicSize - zoom, 1.5f, 5.5f);

            if (Input.GetKey(KeyCode.X))
                isoCamera.orthographicSize = Mathf.Clamp(isoCamera.orthographicSize + zoom, 1.5f, 5.5f);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                yRotation += 90f;

                targetRotation = Quaternion.Euler(30f, yRotation, 0f);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                yRotation -= 90f;

                targetRotation = Quaternion.Euler(30f, yRotation, 0f);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
