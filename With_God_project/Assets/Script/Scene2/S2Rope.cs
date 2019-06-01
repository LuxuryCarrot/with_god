using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SegmentSelectionMode
{
    RoundRobin,
    Random
}

public enum LineOverflowMode
{
    Round,
    Shrink,
    Extend
}

public class S2Rope : MonoBehaviour
{
    public SpriteRenderer[] SegmentsPrefabs;
    public SegmentSelectionMode SegmentsMode;
    public LineOverflowMode OverflowMode;

    //[HideInInspector]

//#if UNITY_5
    //[HideInInspector]
    public bool BreakableJoints=true;
    //[HideInInspector]
    public float BreakForce = 100;

//#endif
    [Range(-0.5f, 0.5f)]
    public float overlapFactor;
    public List<Vector3> nodes = new List<Vector3>(new Vector3[] { new Vector3(-3, 0, 0), new Vector3(3, 0, 0) });
    public bool WithPhysics = true;

    public bool HangFirstSegment = true;
    public bool HangLastSegment = true;
    //[HideInInspector]
    public Vector2 FirstSegmentConnectionAnchor;
    //[HideInInspector]
    public Vector2 LastSegmentConnectionAnchor;

    public bool useBendLimit = true;
    public int bendLimit = 45;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}