using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{
    public GameObject cartePlateformeGelee;

    public emplacementFusion emplacementFusionDroit;
    public emplacementFusion emplacementFusionGauche;
    public GameObject emplacementCarteFusionee;

    public DragAndDropController carteBasePlanche;
    public DragAndDropController carteBaseGlacon;
    public DragAndDropController carteBaseEscalier;    

    /*
        Il faut ajouter une par une les cartes fusion
    */ 
    void Update()
    {
        if(emplacementFusionGauche.cartePlacee() == true && emplacementFusionDroit.cartePlacee() == true)
        {
            //Ca marche jusqu'ici
            if(emplacementFusionDroit.Equals(carteBaseGlacon))
            {
                Debug.Log("Carte Stationnée est la carte Glacon");
                if(emplacementFusionGauche.carteStationnee() == carteBasePlanche)
                {
                    Debug.Log("Carte PlateformeGelée");
                    Instantiate(cartePlateformeGelee, transform.position, transform.rotation);
                    Destroy(emplacementFusionDroit.carteStationnee());
                    Destroy(emplacementFusionGauche.carteStationnee());
                    
                }
            }
            if(emplacementFusionGauche.Equals(carteBaseGlacon))
            {
                Debug.Log("Carte Stationnée est la carte Glacon");
                if(emplacementFusionDroit.carteStationnee() == carteBasePlanche)
                {
                    Debug.Log("Carte PlateformeGelée");
                    Instantiate(cartePlateformeGelee, transform.position, transform.rotation);
                    Destroy(emplacementFusionDroit.carteStationnee());
                    Destroy(emplacementFusionGauche.carteStationnee());
                    
                }
            }
            

        }
    } 
}
