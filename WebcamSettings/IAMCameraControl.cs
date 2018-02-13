using MediaFoundation;
using System;
using System.Runtime.InteropServices;

// see: https://msdn.microsoft.com/en-us/library/windows/desktop/dd389145(v=vs.85).aspx

namespace MFModels
{
    /// <summary>
    /// The IAMCameraControl interface controls web camera settings such as zoom, pan, aperture adjustment,
    /// or shutter speed. To obtain this interface, cast a MediaSource.
    /// </summary>
    [ComImport, System.Security.SuppressUnmanagedCodeSecurity,
    Guid( "C6E13370-30AC-11d0-A18C-00A0C9118956" ),
    InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IAMCameraControl
    {
        /// <summary>
        /// Get the range and default value of a specified camera property.
        /// </summary>
        /// 
        /// <param name="Property">The property to query.</param>
        /// <param name="pMin">The minimum value of the property.</param>
        /// <param name="pMax">The maximum value of the property.</param>
        /// <param name="pSteppingDelta">The step size for the property.</param>
        /// <param name="pDefault">The default value of the property. </param>
        /// <param name="pCapsFlags">Can it be controlled automatically or manually?</param>
        /// 
        /// <returns>Error code.</returns>
        /// 
        [PreserveSig]
        HResult GetRange(
            [In] CameraControlProperty Property,
            [Out] out int pMin,
            [Out] out int pMax,
            [Out] out int pSteppingDelta,
            [Out] out int pDefault,
            [Out] out CameraControlFlags pCapsFlags
            );

        /// <summary>
        /// Set a specified property on the camera.
        /// </summary>
        /// 
        /// <param name="Property">The property to set.</param>
        /// <param name="lValue">The new value of the property.</param>
        /// <param name="Flags">Control it manually or automatically.</param>
        /// 
        /// <returns>Error code.</returns>
        /// 
        [PreserveSig]
        HResult Set(
            [In] CameraControlProperty Property,
            [In] int lValue,
            [In] CameraControlFlags Flags
            );

        /// <summary>
        /// Get the current setting of a camera property.
        /// </summary>
        /// 
        /// <param name="Property">The property to retrieve.</param>
        /// <param name="lValue">The current value of the property.</param>
        /// <param name="Flags">Is it currently manual or automatic?.</param>
        /// 
        /// <returns>Error code.</returns>
        /// 
        [PreserveSig]
        HResult Get(
            [In] CameraControlProperty Property,
            [Out] out int lValue,
            [Out] out CameraControlFlags Flags
            );
    }
}
