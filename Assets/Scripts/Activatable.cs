using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    [SerializeField]
    protected bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void Activate()
    {
        isActive = true; 
    }

    public virtual void Deactivate()
    {
        isActive = false;
    }

    public void Toggle()
    {
        // WTF why doesnt 
        // isActive ? Deactivate() : Activate(); Work
        if (isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }
}
