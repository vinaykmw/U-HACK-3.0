

namespace GoogleARCore
{
    using System.Collections.Generic;
    using GoogleARCoreInternal;
    using UnityEngine;


    [HelpURL("https://developers.google.com/ar/reference/unity/class/GoogleARCore/ARCoreSession")]
    public class ARCoreSession : MonoBehaviour
    {
 
        [Tooltip("A scriptable object specifying the ARCore session configuration.")]
        public ARCoreSessionConfig SessionConfig;

        private OnChooseCameraConfigurationDelegate m_OnChooseCameraConfiguration;

       
        /// <param name="supportedConfigurations">
   
        public delegate int OnChooseCameraConfigurationDelegate(List<CameraConfig> supportedConfigurations);

        [SuppressMemoryAllocationError(Reason = "Could create new LifecycleManager")]
        public void Awake()
        {
            LifecycleManager.Instance.CreateSession(this);
        }


        [SuppressMemoryAllocationError(IsWarning = true, Reason = "Requires further investigation.")]
        public void OnDestroy()
        {
            LifecycleManager.Instance.ResetSession();
        }

 
        [SuppressMemoryAllocationError(Reason = "Enabling session creates a new ARSessionConfiguration")]
        public void OnEnable()
        {
            LifecycleManager.Instance.EnableSession();
        }


        [SuppressMemoryAllocationError(IsWarning = true, Reason = "Requires further investigation.")]
        public void OnDisable()
        {
            LifecycleManager.Instance.DisableSession();
        }


        /// <param name="onChooseCameraConfiguration">The callback to register for selecting a camera configuration.</param>
        public void RegisterChooseCameraConfigurationCallback(OnChooseCameraConfigurationDelegate onChooseCameraConfiguration)
        {
            m_OnChooseCameraConfiguration = onChooseCameraConfiguration;
        }

        internal OnChooseCameraConfigurationDelegate GetChooseCameraConfigurationCallback()
        {
            return m_OnChooseCameraConfiguration;
        }
    }
}
