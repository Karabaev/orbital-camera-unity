using System;
using UnityEngine;

namespace com.karabaev.camera.unity.Views
{
  public interface ICameraTarget
  {
    Func<Vector3> PositionFunc { get; }
  }
}