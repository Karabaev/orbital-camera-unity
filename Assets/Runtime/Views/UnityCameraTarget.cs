using System;
using UnityEngine;

namespace com.karabaev.camera.unity.Views
{
  public class UnityCameraTarget : MonoBehaviour, ICameraTarget
  {
    public Func<Vector3> PositionFunc { get; }

    private Vector3 ProvidePosition() => transform.position;

    public UnityCameraTarget() => PositionFunc = ProvidePosition;
  }
}