﻿using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public enum LevelDifficulty
{
    Safe,
    Euclid,
    Keter
}

public class Main : MonoBehaviour
{
    public Texture handsymbol, handsymbol2;
    public AudioClip toBeContinued, pickItem, operateDoor;
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    public float fps;

    void Start()
    {
        AI.nodegraph = GameObject.FindGameObjectsWithTag("Navigation Node");
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }
}

public static class Helper
{
    public static readonly List<KeyCode> keyCodes = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().ToList();
    public static List<GameObject> disabled = new List<GameObject>();

    public static bool InFacility(GameObject gameObject)
    {
        Vector3 pos = gameObject.transform.position;
        return pos.x < 33 && pos.z > -43.5;
    }
}
