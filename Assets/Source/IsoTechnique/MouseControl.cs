using UnityEngine;

namespace Study.IsoCamera.Interaction
{
    public class MouseControl : MonoBehaviour
    {
        // Update is called once per frame
        void FixedUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    if (Input.GetMouseButtonDown(0))
                        Debug.Log("Clicked " + hit.collider.name);
                }
            }
        }
    }
}
