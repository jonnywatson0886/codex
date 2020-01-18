using System;
using DemoLibrary;
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

namespace API1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartPage  : Window
    {
        #region vars
        private int maxNumber = 0;
        private int currentNumber = 0;
        bool programRunning = false;
        #endregion
        #region constructor
        public StartPage()
        {
            InitializeComponent();
            //make new HTTPS client
            APIHelper.NewAPIClient();
            //make sure user can't hit next and back button if the button is off
            NextBut.IsEnabled = false;
            LastPageBut.IsEnabled = false;
        }
        #endregion
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get the data model for the api made 
                var image = await ImageProcessor.LoadImage();

                //get the image url and use it as a bitmap for the image source on the page
                var imageSource = new Uri(image.Img, UriKind.Absolute);
                MainImage.Source = new BitmapImage(imageSource);

                //set the number of comics to updated numbers
                maxNumber = image.Num;
                currentNumber = maxNumber;
                //let us go backwards but not forwards
                LastPageBut.IsEnabled = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Loading in image failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void NextBut_Click(object sender, RoutedEventArgs e)
        {
            currentNumber++;
            ImageModel comic = await ImageProcessor.LoadImage(currentNumber);

            Uri imageSource = new Uri(comic.Img);
            MainImage.Source = new BitmapImage(imageSource);

            if (currentNumber == maxNumber)
            {
                NextBut.IsEnabled = false;
            }
            if (!LastPageBut.IsEnabled)
            {
                LastPageBut.IsEnabled = true;
            }
        }

        /// <summary>
        ///create a new visual test page and delete the current page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPageBut_Click(object sender, RoutedEventArgs e)
        {
            programRunning = true;
            VisualProgrammingTest visualProgramming = new VisualProgrammingTest();
            visualProgramming.Show();
            this.Close();
        }

        /// <summary>
        /// used to go back one comic 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void LastPageBut_Click(object sender, RoutedEventArgs e)
        {
            currentNumber--;
            ImageModel comic = await ImageProcessor.LoadImage(currentNumber);

            Uri imageSource = new Uri(comic.Img);
            MainImage.Source = new BitmapImage(imageSource);

            if (currentNumber < 2)
            {
                LastPageBut.IsEnabled = false;
            }
            NextBut.IsEnabled = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!programRunning)
            {
                Application.Current.Shutdown();   
            }
        }
    }
}
