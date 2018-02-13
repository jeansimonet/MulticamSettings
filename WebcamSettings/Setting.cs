using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaFoundation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DirectShowLib;

namespace WebcamSettings
{
    public interface ISetting
    {
        string Name { get; }
        int Min { get; }
        int Max { get; }
        int Delta { get; }
        int Value { get; set; }
        bool CanBeAuto { get; }
        bool Auto { get; set; }
    }

    class CamSetting : ISetting
    {
        IAMCameraControl _CamFilter;
        CameraControlProperty _CamProperty;
        CameraControlFlags _PossibleFlags;
        string _Name;
        int _Min;
        int _Max;
        int _Delta;
        int _Value;
        CameraControlFlags _Flags;
        int _Default;
        bool _ReadDirty;

        public CamSetting(IAMCameraControl filter, CameraControlProperty property)
        {
            _CamFilter = filter;
            _CamProperty = property;
            _Name = property.ToString();

            // Update all defaults min max, etc...
            Read();
        }

        public void UpdateTarget(IAMCameraControl filter)
        {
            _CamFilter = filter;
            Read();
        }

        public void Read()
        {
            if (_CamFilter.GetRange(_CamProperty, out _Min, out _Max, out _Delta, out _Default, out _PossibleFlags) != 0)
            {
                Console.Error.WriteLine("Could not retrieve camera ranges");
            }
            if (_CamFilter.Get(_CamProperty, out _Value, out _Flags) != 0)
            {
                Console.Error.WriteLine("Could not retrieve camera value");
            }
            _ReadDirty = false;
        }

        public void Write()
        {
            // Write values
            if (_CamFilter.Set(_CamProperty, _Value, _Flags) != 0)
            {
                Console.Error.WriteLine("Could not set camera value");
            }

            // Make sure we read it back!
            _ReadDirty = true;
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public int Min
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Min;
            }
        }
        public int Max
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Max;
            }
        }
        public int Delta
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Delta;
            }
        }
        public int Value
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Value;
            }
            set
            {
                _Value = value;
                Write();
            }
        }
        public bool CanBeAuto
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _PossibleFlags.HasFlag(CameraControlFlags.Auto);
            }
        }
        public bool Auto
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Flags == CameraControlFlags.Auto;
            }
            set
            {
                if (value)
                    _Flags = CameraControlFlags.Auto;
                else
                    _Flags = CameraControlFlags.Manual;
                Write();
            }
        }
    }

    class VideoSetting : ISetting
    {
        IAMVideoProcAmp _CamFilter;
        VideoProcAmpProperty _CamProperty;
        VideoProcAmpFlags _PossibleFlags;
        string _Name;
        int _Min;
        int _Max;
        int _Delta;
        int _Value;
        VideoProcAmpFlags _Flags;
        int _Default;
        bool _ReadDirty;

        public VideoSetting(IAMVideoProcAmp filter, VideoProcAmpProperty property)
        {
            _CamFilter = filter;
            _CamProperty = property;
            _Name = property.ToString();

            // Update all defaults min max, etc...
            Read();
        }

        public void UpdateTarget(IAMVideoProcAmp filter)
        {
            _CamFilter = filter;
            Read();
        }

        public void Read()
        {
            if (_CamFilter.GetRange(_CamProperty, out _Min, out _Max, out _Delta, out _Default, out _PossibleFlags) != 0)
            {
                Console.Error.WriteLine("Could not retrieve camera ranges");
            }
            if (_CamFilter.Get(_CamProperty, out _Value, out _Flags) != 0)
            {
                Console.Error.WriteLine("Could not retrieve camera value");
            }
            _ReadDirty = false;
        }

        public void Write()
        {
            // Write values
            if (_CamFilter.Set(_CamProperty, _Value, _Flags) != 0)
            {
                Console.Error.WriteLine("Could not set camera value");
            }

            // Make sure we read it back!
            _ReadDirty = true;
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public int Min
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Min;
            }
        }
        public int Max
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Max;
            }
        }
        public int Delta
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Delta;
            }
        }
        public int Value
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Value;
            }
            set
            {
                _Value = value;
                Write();
            }
        }
        public bool CanBeAuto
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _PossibleFlags.HasFlag(VideoProcAmpFlags.Auto);
            }
        }
        public bool Auto
        {
            get
            {
                if (_ReadDirty)
                    Read();
                return _Flags == VideoProcAmpFlags.Auto;
            }
            set
            {
                if (value)
                    _Flags = VideoProcAmpFlags.Auto;
                else
                    _Flags = VideoProcAmpFlags.Manual;
                Write();
            }
        }
    }
}
