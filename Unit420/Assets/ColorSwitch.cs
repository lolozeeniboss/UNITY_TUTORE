using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    // color == "Red" si la couleur de l'elastique sur lequel se trouve le joueur est rouge, color == "Blue" si l'elastique est bleu
    public void switchColor(string color, string currentSlingshot)
    {
        foreach (Transform child in transform)
        {
            //Si il s'agit de l'objet contenant les elastiques de la couleur qu'on souhaite desactiver (cad la couleur de l'elastique sur lequel se trouve le joueur)
            if (child.name.Equals(color))
            {
                foreach (Transform slingshot in child.transform) {
                    //On desactive tous les elastiques de cette couleur sauf celui sur lequel est le joueur
                    if (!slingshot.name.Equals(currentSlingshot))
                    {
                        slingshot.gameObject.SetActive(false);
                    }
                }
            } else
            {
                foreach (Transform slingshot in child.transform)
                {
                    slingshot.gameObject.SetActive(true);
                }
            }
            
        }
    }
}
