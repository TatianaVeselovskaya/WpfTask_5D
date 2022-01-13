using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Windows.Ink;


namespace WpfTask_5D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "InkCanvas Format (*.sandy)|*.sandy|All files(*.*)|*.*";
            if (dig.ShowDialog() == true)
            {
                var fs = new FileStream(dig.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fs);
                InkCanvas.Strokes = strokes;
            }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "InkCanvas Format (*.sandy)|*.sandy|All files(*.*)|*.*";
            if (dig.ShowDialog() == true)
            {
                FileStream fs = File.Open(dig.FileName, FileMode.OpenOrCreate);
                InkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonPencil(object sender, RoutedEventArgs e)
        {
            InkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
            InkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
            ClearSelection();
        }

        private void ClearSelection()
        {
            throw new NotImplementedException();
        }

        private void ButtonEraser(object sender, RoutedEventArgs e)
        {
            var strokes = InkCanvas.InkPresenter.StrokeContainer.GetStrokes();
            foreach (var stroke in strokes)
            {
                stroke.Selected = false;
            }
            ClearDrawnBoundingRect();
        }

        private void ClearDrawnBoundingRect()
        {
            throw new NotImplementedException();
        }
    }
}
