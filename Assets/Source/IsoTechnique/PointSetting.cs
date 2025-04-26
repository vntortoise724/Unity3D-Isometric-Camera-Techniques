using System.Collections;
using UnityEngine;

public class PointSetting : MonoBehaviour
{
    [SerializeField] private float pointDis;
    [SerializeField] private float waitTime = 3f;

    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= pointDis)
            Destroy(gameObject);
        else
            StartCoroutine(DestroyWhenTooLong());
    }

    private IEnumerator DestroyWhenTooLong()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
