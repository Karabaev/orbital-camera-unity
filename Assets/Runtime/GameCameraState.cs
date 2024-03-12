using System.Collections;
using System.Collections.Generic;
using com.karabaev.reactivetypes.Property;
using UnityEngine;

namespace com.karabaev.camera.unity
{
  public class GameCameraState
  {
    public ReactiveProperty<Vector3> Position { get; }
    
    public ReactiveProperty<Vector3> Rotation { get; }
    
    public ReactiveProperty<UnityEngine.Camera> Camera { get; }
    
    public ReactiveProperty<string?> TargetObjectId { get; }
    
    public GameInputModel Input { get; }
    
    public GameCameraState(Vector3 position, Vector3 rotation, GameInputModel input)
    {
      Position = new ReactiveProperty<Vector3>(position);
      Rotation = new ReactiveProperty<Vector3>(rotation);
      Camera = new ReactiveProperty<UnityEngine.Camera>(null!);
      TargetObjectId = new ReactiveProperty<string?>(null);
      Input = input;
    }
  }
}