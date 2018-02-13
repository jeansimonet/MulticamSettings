/// <summary>
/// DirectShow definitions pulled from the headers
/// </summary>
using System;

namespace MFModels
{
    // See CppSDK\SDK\include\shared\ksmedia.h
    //    typedef enum {
    //        KSPROPERTY_CAMERACONTROL_PAN,                       // RW O
    //        KSPROPERTY_CAMERACONTROL_TILT,                      // RW O
    //        KSPROPERTY_CAMERACONTROL_ROLL,                      // RW O
    //        KSPROPERTY_CAMERACONTROL_ZOOM,                      // RW O
    //        KSPROPERTY_CAMERACONTROL_EXPOSURE,                  // RW O
    //        KSPROPERTY_CAMERACONTROL_IRIS,                      // RW O
    //        KSPROPERTY_CAMERACONTROL_FOCUS                      // RW O
    //    KSPROPERTY_VIDCAP_CAMERACONTROL;

    /// <summary>
    /// The list of camera property settings
    /// </summary>
    public enum CameraControlProperty
    {
        Pan = 0,
        Tilt,
        Roll,
        Zoom,
        Exposure,
        Iris,
        Focus
    }

    /// <summary>
    /// Is the setting automatic?
    /// </summary>
    [Flags]
    public enum CameraControlFlags
    {
        None = 0x0,
        Auto = 0x0001,
        Manual = 0x0002
    }
}
