using UnityEngine;

namespace com.karabaev.camera.unity.States
{
  public interface ICameraInputState
  {
    float MouseWheelAxis { get; }
    
    Vector2 AuxMouseButtonDragAxis { get; }
  }
}