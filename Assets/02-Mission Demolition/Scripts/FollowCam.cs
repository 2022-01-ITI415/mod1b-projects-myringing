using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public FollowCam S;
    public bool _____________________________;
    public GameObject poi;
    public float camZ;

    private void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (poi == null) return;
        Vector3 destination = poi.transform.position;
        destination.z = camZ;
        transform.position = destination;
    }
}
