using System.Diagnostics.CodeAnalysis;
using com.karabaev.camera.unity.Descriptors;
using com.karabaev.camera.unity.States;
using UnityEngine;

namespace com.karabaev.camera.unity.Views
{
  [SuppressMessage("ReSharper", "Unity.RedundantHideInInspectorAttribute")]
  public class GameCameraView : MonoBehaviour
  {
    private GameCameraConfigDescriptor _config = null!;
    private IReadOnlyGameCameraState _state = null!;
    private ICameraInputState _inputState = null!;
    
    private float _currentZoom;
    private Vector2 _orbitAngles;
    private ICameraTarget? _target;
    private Vector3 _focusPoint;

    private bool _isConstructed;
    
    private void Awake() => enabled = false;

    public void Construct(GameCameraConfigDescriptor config, IReadOnlyGameCameraState state, ICameraInputState inputState)
    {
      _currentZoom = config.InitialZoom;
      _orbitAngles = config.InitialOrbitAngles;

      _config = config;
      _state = state;
      _inputState = inputState;
      _state.Position.Changed += Model_OnPositionChanged;
      _state.Rotation.Changed += Model_OnRotationChanged;
      _state.Target.Changed += Model_OnTargetObjectIdChanged;
      enabled = true;
      _isConstructed = true;
    }

    private void Model_OnPositionChanged(Vector3 oldValue, Vector3 newValue) => transform.position = newValue;

    private void Model_OnRotationChanged(Vector3 oldValue, Vector3 newValue) => transform.eulerAngles = newValue;

    private void Model_OnTargetObjectIdChanged(ICameraTarget? oldValue, ICameraTarget? newValue) => _target = newValue;

    private void OnEnable()
    {
      _state.Position.Changed -= Model_OnPositionChanged;
      _state.Rotation.Changed -= Model_OnRotationChanged;
      _state.Target.Changed -= Model_OnTargetObjectIdChanged;
      
      _state.Position.Changed += Model_OnPositionChanged;
      _state.Rotation.Changed += Model_OnRotationChanged;
      _state.Target.Changed += Model_OnTargetObjectIdChanged;
    }

    private void OnDisable()
    {
      if(!_isConstructed)
        return;
      
      _state.Position.Changed -= Model_OnPositionChanged;
      _state.Rotation.Changed -= Model_OnRotationChanged;
      _state.Target.Changed -= Model_OnTargetObjectIdChanged;
    }

    private void Update()
    {
      _currentZoom = CalculateZoom();
      _orbitAngles = CalculateOrbitAngles(Time.deltaTime);
    }

    private float CalculateZoom()
    {
      var inputWheelAxis = _inputState.MouseWheelAxis;
      if(inputWheelAxis == 0.0f)
        return _currentZoom;
      
      return Mathf.Clamp(_currentZoom - inputWheelAxis * _config.ZoomSensitivity, _config.MinZoom, _config.MaxZoom);
    }
    
    private Vector2 CalculateOrbitAngles(float deltaTime)
    {
      var input = _inputState.AuxMouseButtonDragAxis;
      
      var invertedInput = new Vector2(-input.y, -input.x);
      var orbitAngles = _orbitAngles + _config.RotationSensitivity * deltaTime * invertedInput;
      orbitAngles.x = Mathf.Clamp(orbitAngles.x, _config.MinOrbitAngle, _config.MaxOrbitAngle);
      switch(orbitAngles.y)
      {
        case < 0f:
          orbitAngles.y += 360f;
          break;
        case >= 360f:
          orbitAngles.y -= 360f;
          break;
      }
      
      return orbitAngles;
    }
    
    private void LateUpdate()
    {
      if(_target == null)
        return;

      var targetPosition = _target.PositionFunc.Invoke();
      
      var distance = Vector3.Distance(targetPosition, _focusPoint);
      var t = 1.0f;
      if(distance > 0.01f && _config.FocusCentering > 0f)
        t = Mathf.Pow(1f - _config.FocusCentering, Time.deltaTime);

      if(distance > _config.FocusRadius)
        t = Mathf.Min(t, _config.FocusRadius / distance);

      _focusPoint = Vector3.Lerp(targetPosition, _focusPoint, t);

      var lookRotation = Quaternion.Euler(_orbitAngles);
      var lookDirection = lookRotation * Vector3.forward;
      var lookPosition = _focusPoint - lookDirection * _currentZoom;
      transform.SetPositionAndRotation(lookPosition, lookRotation);
    }
  }
}