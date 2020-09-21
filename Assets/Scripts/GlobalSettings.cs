using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static GlobalSettings globalsettings;


    private static int changecardscount = 2;
    private static int fightstepscount = 3;
    private static int maxhandcounter = 5;
    private static int maxtablecounter = 3;
    public WebCamDevice[] Devices;

    private bool _firstTime=true;

    public bool FirstTime { get => _firstTime; set => _firstTime = value; }
    public static int Changecardscount { get => changecardscount; }
    public static int Fightstepscount { get => fightstepscount; }
    public static int Maxhandcounter { get => maxhandcounter; }
    public static int Maxtablecounter { get => maxtablecounter; }

    private void Awake()
    {
        if (globalsettings != null)
            Destroy(this);
        if (globalsettings == null)
            globalsettings = this;
        
    }
    private void Start()
    {
        Devices = WebCamTexture.devices;
    }
}
