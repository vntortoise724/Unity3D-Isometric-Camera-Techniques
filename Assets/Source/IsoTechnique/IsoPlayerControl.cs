using UnityEngine;
using Study.IsoCamera.Control;

public class IsoPlayerControl : MonoBehaviour
{

    private Transform isoPivot;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isoPivot = FindFirstObjectByType<IsoCameraControl>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isoPivot == null)
            return;
        else
            isoPivot.position = player.position;
    }
}
