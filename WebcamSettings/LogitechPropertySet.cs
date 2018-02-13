using MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WebcamSettings
{
    /// <summary>
    /// The list of camera property settings
    /// </summary>
    public enum LogitechProperty
    {
        // Version = 0, // Don't care!
        Pan = 1, // Control the digital pan position
        Tilt, // Control the digital tilt position
        Zoom, // Control the digital zoom factor
        PanTiltZoom, // Control the digital pan and tilt positions and digital zoom factor
        ExposureTime, // Control the exposure time and automatic exposure mode
        FaceTracking, // Enable or disable single and multiple face tracking
        Led, // Control the LED behavior
        FindFace,
    }

    public enum LVUVC_LP1_FACE_TRACKING_MODE
    {
        LVUVC_LP1_FACE_TRACKING_MODE_OFF,
        LVUVC_LP1_FACE_TRACKING_MODE_SINGLE,
        LVUVC_LP1_FACE_TRACKING_MODE_MULTIPLE,
    }


    public enum LVUVC_LP1_LED_MODE
    {
        LVUVC_LP1_LED_MODE_OFF,
        LVUVC_LP1_LED_MODE_ON,
        LVUVC_LP1_LED_MODE_BLINKING,
        LVUVC_LP1_LED_MODE_AUTO,
    }


    public enum LVUVC_LP1_FINDFACE_MODE
    {
        LVUVC_LP1_FINDFACE_MODE_NO_CHANGE,
        LVUVC_LP1_FINDFACE_MODE_OFF,
        LVUVC_LP1_FINDFACE_MODE_ON,
    }


    public enum LVUVC_LP1_FINDFACE_RESET
    {
        LVUVC_LP1_FINDFACE_RESET_NONE,
        LVUVC_LP1_FINDFACE_RESET_DEFAULT,
        LVUVC_LP1_FINDFACE_RESET_FACE,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_HEADER
    {
        public int ulFlags;
        public int ulReserved1;
        public int ulReserved2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_VERSION_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public short usMajor;
        public short usMinor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_DIGITAL_PAN_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public int lPan;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_DIGITAL_TILT_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public int lTilt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_DIGITAL_ZOOM_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public int ulZoom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_DIGITAL_PANTILTZOOM_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public int lPan;
        public int lTilt;
        public int ulZoom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_EXPOSURE_TIME_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public int ulExposureTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_FACE_TRACKING_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public LVUVC_LP1_FACE_TRACKING_MODE ulMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_LED_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public LVUVC_LP1_LED_MODE ulMode;
        public int ulFrequency;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KSPROPERTY_LP1_FINDFACE_S
    {
        public KSPROPERTY_LP1_HEADER Header;
        public LVUVC_LP1_FINDFACE_MODE ulMode;
        public LVUVC_LP1_FINDFACE_RESET ulReset;
    }

    //IKsPropertySet propertySet = capFilter as IKsPropertySet;
    //int size = Marshal.SizeOf<KSPROPERTY_LP1_VERSION_S>();
    //IntPtr data = Marshal.AllocHGlobal(size);
    //int returnedByteCount;
    //int hr = propertySet.Get(Guid.Parse("CAAE4966-272C-44a9-B792-71953F89DB2B"), 0, IntPtr.Zero, 0, data, size, out returnedByteCount);
    //KSPROPERTY_LP1_VERSION_S version = Marshal.PtrToStructure<KSPROPERTY_LP1_VERSION_S>(data);
    //Marshal.FreeHGlobal(data);

    //        size = Marshal.SizeOf<KSPROPERTY_LP1_FACE_TRACKING_S>();
    //        data = Marshal.AllocHGlobal(size);
    //        hr = propertySet.Get(Guid.Parse("CAAE4966-272C-44a9-B792-71953F89DB2B"), 6, IntPtr.Zero, 0, data, size, out returnedByteCount);
    //        KSPROPERTY_LP1_FACE_TRACKING_S face = Marshal.PtrToStructure<KSPROPERTY_LP1_FACE_TRACKING_S>(data);
    //Marshal.FreeHGlobal(data);
    //        face.ulMode = 0;
    //        data = Marshal.AllocHGlobal(size);
    //        Marshal.StructureToPtr<KSPROPERTY_LP1_FACE_TRACKING_S>(face, data, false);
    //        hr = propertySet.Set(Guid.Parse("CAAE4966-272C-44a9-B792-71953F89DB2B"), 6, IntPtr.Zero, 0, data, size);
    //        Marshal.FreeHGlobal(data);


}
