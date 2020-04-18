using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freecambutton : MonoBehaviour
{
    public GameObject indicator;
    bool isActive = false;
    // Start is called before the first frame update

    void Start()
    {
        indicator.SetActive(false);
    }

    public void Switch(){
        isActive = !isActive;
        indicator.SetActive(isActive);
        Debug.Log(isActive);
    }

}
