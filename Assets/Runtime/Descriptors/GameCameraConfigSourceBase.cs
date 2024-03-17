using com.karabaev.descriptors.abstractions.Initialization;
using com.karabaev.descriptors.unity;

namespace com.karabaev.camera.unity.Descriptors
{
  public abstract class GameCameraConfigSourceBase<TProvider> : ScriptableObjectDescriptorRegistrySource<string, GameCameraConfigDescriptor, TProvider> 
    where TProvider : IDescriptorSourceProvider { }
}