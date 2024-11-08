using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject background1;
    public GameObject background2;

    public void SwitchBackground(){
         background1.SetActive(false);
        background2.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
