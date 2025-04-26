using UnityEngine;

namespace Study.IsoCamera.Movement
{
    public class PlayerMovementMouse : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private GameObject pointPrefab;
        [SerializeField] private LayerMask groundLayer;

        private Vector3 targetPosition;
        private bool isMoving;

        private Rigidbody rb;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1)) 
            { 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (((1 << hit.transform.gameObject.layer) & groundLayer) != 0)
                    {
                        targetPosition = hit.point;

                        Instantiate(pointPrefab, targetPosition, Quaternion.identity);

                        isMoving = true;
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                Vector3 direction = targetPosition - rb.position;
                direction.y = 0f;
                float distance = direction.magnitude;

                if (distance > .1f)
                {
                    Vector3 move = moveSpeed * Time.fixedDeltaTime * direction.normalized;
                    rb.MovePosition(rb.position + move);

                    Quaternion rotation = Quaternion.LookRotation(direction);
                    rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotation, 10f * Time.fixedDeltaTime));
                }
                else isMoving = false;
            }
        }
    }
}
