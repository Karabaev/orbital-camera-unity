using System;
using com.karabaev.descriptors.abstractions;
using UnityEngine;

namespace com.karabaev.camera.unity.Descriptors
{
  [Serializable]
  public class GameCameraConfigDescriptor : IDescriptor
  {
    [field: SerializeField]
    public float MaxZoom { get; private set; } = 15.0f;
    
    [field: SerializeField]
    public float MinZoom { get; private set; } = 4.0f;
    
    [field: SerializeField]
    public float InitialZoom { get; private set; } = 10.0f;

    [field: SerializeField]
    public float ZoomSensitivity { get; private set; } = 5.0f;
    
    [field: SerializeField]
    public Vector2 InitialOrbitAngles { get; private set; } = new(45.0f, 0.0f);
    
    [field: SerializeField, Range(1.0f, 360.0f)]
    public float RotationSensitivity { get; private set; } = 5.0f;

    [field: SerializeField, Range(0.0f, 90.0f)]
    public float MaxOrbitAngle { get; private set; } = 60.0f;
    
    [field: SerializeField, Range(0.0f, 90.0f)]
    public float MinOrbitAngle { get; private set; } = 20.0f;

    [field: SerializeField, Range(0.0f, 5.0f)]
    public float FocusRadius { get; private set; } = 1.0f;
    
    [field: SerializeField, Range(0.0f, 1.0f)]
    public float FocusCentering { get; private set; } = 0.9f;
  }
}