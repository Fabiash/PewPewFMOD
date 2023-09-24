using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootModulesCounter : MonoBehaviour
{
    public GameObject[] shootModules;
    public GameObject[] followers;
    public GameObject[] shieldModules;
    

    private int activeModules;
    private bool arpOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeModules = 0;

        foreach (var module in shootModules)
        {
            if (module.activeSelf)
            {
                activeModules++;
            }
        }
        foreach (var module in followers)
        {
            if (module.activeSelf)
            {
                activeModules++;
            }
        }
        foreach (var module in shieldModules)
        {
            if (module.activeSelf)
            {
                activeModules++;
            }
        }
        
        if (activeModules > 0 &&
            arpOn == false)
        {

        }
    }
}
