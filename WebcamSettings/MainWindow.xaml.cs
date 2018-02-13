using DirectShowLib;
using MediaFoundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebcamSettings
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Webcam> webcams;
        ObservableCollection<ISetting> camSettings;

        public MainWindow()
        {
            InitializeComponent();

            webcams = new List<Webcam>();

            DsDevice[] captureDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var dv in captureDevices)
            {
                webcams.Add(new Webcam()
                {
                    Name = dv.Name,
                    Moniker = dv.Mon,
                    UserName = "<user defined name>",
                });
            }
            lbWebcams.ItemsSource = webcams;

            camSettings = new ObservableCollection<ISetting>();
            lbControls.ItemsSource = camSettings;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            var setting = slider.DataContext as ISetting;
            setting.Value = (int)e.NewValue;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            var setting = checkbox.DataContext as ISetting;
            setting.Auto = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            var setting = checkbox.DataContext as ISetting;
            setting.Auto = false;
        }

        private void lbWebcams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            camSettings.Clear();
            var cam = lbWebcams.SelectedItem as Webcam;

            // Update all settings
            IFilterGraph2 graphBuilder = new FilterGraph() as IFilterGraph2;
            IBaseFilter capFilter = null;
            graphBuilder.AddSourceFilterForMoniker(cam.Moniker, null, cam.Name, out capFilter);

            foreach (var val in typeof(CameraControlProperty).GetEnumValues())
            {
                camSettings.Add(new CamSetting(capFilter as IAMCameraControl, (CameraControlProperty)(int)val));
            }
            foreach (var val in typeof(VideoProcAmpProperty).GetEnumValues())
            {
                camSettings.Add(new VideoSetting(capFilter as IAMVideoProcAmp, (VideoProcAmpProperty)(int)val));
            }
        }
    }
}
