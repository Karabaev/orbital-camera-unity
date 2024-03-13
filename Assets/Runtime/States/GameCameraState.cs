using com.karabaev.camera.unity.Views;
using com.karabaev.reactivetypes.Property;
using UnityEngine;

namespace com.karabaev.camera.unity.States
{
  public class GameCameraState : IReadOnlyGameCameraState, IWriteOnlyGameCameraState
  {
    public ReactiveProperty<Vector3> Position { get; } = new(default);
    
    public ReactiveProperty<Vector3> Rotation { get; } = new(default);
    
    public ReactiveProperty<ICameraTarget?> Target { get; } = new(default);

    IReadOnlyReactiveProperty<Vector3> IReadOnlyGameCameraState.Position => Position;

    IReadOnlyReactiveProperty<Vector3> IReadOnlyGameCameraState.Rotation => Rotation;

    IReadOnlyReactiveProperty<ICameraTarget?> IReadOnlyGameCameraState.Target => Target;

    IWriteOnlyReactiveProperty<Vector3> IWriteOnlyGameCameraState.Position => Position;

    IWriteOnlyReactiveProperty<Vector3> IWriteOnlyGameCameraState.Rotation => Rotation;

    IWriteOnlyReactiveProperty<ICameraTarget?> IWriteOnlyGameCameraState.Target => Target;
  }

  public interface IReadOnlyGameCameraState
  {
    IReadOnlyReactiveProperty<Vector3> Position { get; }
    
    IReadOnlyReactiveProperty<Vector3> Rotation { get; }
    
    IReadOnlyReactiveProperty<ICameraTarget?> Target { get; }
  }
  
  public interface IWriteOnlyGameCameraState
  {
    IWriteOnlyReactiveProperty<Vector3> Position { get; }
    
    IWriteOnlyReactiveProperty<Vector3> Rotation { get; }
    
    IWriteOnlyReactiveProperty<ICameraTarget?> Target { get; }
  }
}