using com.karabaev.reactivetypes.Property;
using UnityEngine;

namespace com.karabaev.camera.unity.States
{
  public class GameCameraState : IReadOnlyGameCameraState, IWriteOnlyGameCameraState
  {
    public ReactiveProperty<Vector3> Position { get; } = new(default);
    
    public ReactiveProperty<Vector3> Rotation { get; } = new(default);
    
    public ReactiveProperty<string?> TargetObjectId { get; } = new(default);

    IReadOnlyReactiveProperty<Vector3> IReadOnlyGameCameraState.Position => Position;

    IReadOnlyReactiveProperty<Vector3> IReadOnlyGameCameraState.Rotation => Rotation;

    IReadOnlyReactiveProperty<string?> IReadOnlyGameCameraState.TargetObjectId => TargetObjectId;

    IWriteOnlyReactiveProperty<Vector3> IWriteOnlyGameCameraState.Position => Position;

    IWriteOnlyReactiveProperty<Vector3> IWriteOnlyGameCameraState.Rotation => Rotation;

    IWriteOnlyReactiveProperty<string?> IWriteOnlyGameCameraState.TargetObjectId => TargetObjectId;
  }

  public interface IReadOnlyGameCameraState
  {
    IReadOnlyReactiveProperty<Vector3> Position { get; }
    
    IReadOnlyReactiveProperty<Vector3> Rotation { get; }
    
    IReadOnlyReactiveProperty<string?> TargetObjectId { get; }
  }
  
  public interface IWriteOnlyGameCameraState
  {
    IWriteOnlyReactiveProperty<Vector3> Position { get; }
    
    IWriteOnlyReactiveProperty<Vector3> Rotation { get; }
    
    IWriteOnlyReactiveProperty<string?> TargetObjectId { get; }
  }
}