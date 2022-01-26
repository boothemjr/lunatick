using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhaser : MonoBehaviour
{
    private BoxCollider2D myBody;
    private SpriteRenderer myRenderer;
    public PhaseManager phaseManager;

    private Color darkOpaque = new Color(58f/255f,28f/255f,72f/255f,1f);
    private Color darkTransparent = new Color(58f/255f,28f/255f,72f/255f,200f/255f);

    private Color lightOpaque = new Color(168/255f,162/255f,77/255f,1f);
    private Color lightTransparent = new Color(168f/255f,162f/255f,77f/255f,200/255f);
    
    public bool isLight = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<BoxCollider2D>() as BoxCollider2D; 
        myRenderer = GetComponent<SpriteRenderer>(); 
        phaseManager = GameObject.FindWithTag("Phase Manager").GetComponent<PhaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLight)
        {
            if (phaseManager.light) 
            {
                myBody.enabled = true;
                myRenderer.color = new Color(168/255f,162/255f,77/255f,1f);
            }
            else if (!phaseManager.light) 
            {
                myBody.enabled = false;
                myRenderer.color = new Color(168f/255f,162f/255f,77f/255f,140/255f);
            }
        }
        else if (!isLight)
        {
            if (!phaseManager.light) 
            {
                myBody.enabled = true;
                myRenderer.color = new Color(58f/255f,28f/255f,72f/255f,1f);
            }
            else if (phaseManager.light) 
            {
                myBody.enabled = false;
                myRenderer.color = new Color(58f/255f,28f/255f,72f/255f,140f/255f);
            }
        }
    }

}
