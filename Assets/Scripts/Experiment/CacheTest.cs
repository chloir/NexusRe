using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CacheTest : MonoBehaviour
{
    private Vector3 _vel = new Vector3(1, 0, 0);
    private Transform _thisTransform;
    
    Stopwatch sw = new Stopwatch();
    
    void Start()
    {
        _thisTransform = transform;
        
        sw.Start();

        for (int i = 0; i < 100000; i++)
        {
            transform.position += _vel;
        }
        
        sw.Stop();
        UnityEngine.Debug.Log($"transform.position : {sw.Elapsed}");
        
        sw.Reset();
        
        sw.Start();

        for (int i = 0; i < 100000; i++)
        {
            _thisTransform.position += _vel;
        }
        
        sw.Stop();
        UnityEngine.Debug.Log($"cached : {sw.Elapsed}");
    }
}
