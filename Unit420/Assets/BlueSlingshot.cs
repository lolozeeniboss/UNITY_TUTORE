using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlingshot : SlingShotV3
{
    private void Start()
    {
        leftString.material.color = Color.blue;
        rightString.material.color = Color.blue;
        rightString.SetPosition(1, leftString.transform.position);
        leftString.enabled = false;
        disableStrings();
    }

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        //Debug.Log("I'm blue!");
        ColorSwitch parentScript = this.transform.parent.transform.parent.GetComponent<ColorSwitch>();
        parentScript.switchColor(transform.parent.name, name);
    }
}
