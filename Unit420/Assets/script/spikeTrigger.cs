using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeTrigger : MonoBehaviour
{
    private GameObject spike;
    private Vector3 startSpikeTransformPosition;
    private Vector3 startTransformPosition;
    public float speed;
    private bool moving;
    public float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moving = true;

    }

    private void Awake()
    {
        spike  = transform.parent.gameObject.transform.GetChild(0).gameObject;
        moving = false;
        startSpikeTransformPosition = cloneVector3(spike.transform.localPosition);
        startTransformPosition = cloneVector3(gameObject.transform.localPosition);
        Debug.Log(startTransformPosition);
    }

    private void Update()
    {
        
        if (moving)
        {
            spike.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, spike.transform.localPosition, speed);
            if (!IsInvoking("retraction"))
            {
                Invoke("retraction", timer);
            }
        }

    }

    private void retraction()
    {
        spike.transform.localPosition = startSpikeTransformPosition;
        moving = false;
    }


    private Vector3 cloneVector3(Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }



}
