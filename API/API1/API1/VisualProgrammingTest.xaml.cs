using System;
using System.Collections.Generic;
using System.Linq;
using DemoLibrary.APIProcessing;
using DemoLibrary.DataModels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DemoLibrary;

namespace API1
{
    /// <summary>
    /// Interaction logic for VisualProgrammingTest.xaml
    /// </summary>
    public partial class VisualProgrammingTest : Window
    {

        private List<CheckListDataModel> TrueList;
        private List<CheckListDataModel> FalseList;
        bool programRunning = false;
        public VisualProgrammingTest()
        {
            InitializeComponent();
            APIHelper.NewAPIClient();   
        }

        private async void GetData_Click(object sender, RoutedEventArgs e)
        {
            if (APIHelper.CheckForInternetConnection())
            {
                TrueList = new List<CheckListDataModel>();
                FalseList = new List<CheckListDataModel>();
                clearlists();

                var rawData = await SchoolChecklistProcessor.GetCheckListDataAysnc();
                foreach (CheckListDataModel x in rawData)
                {
                    if (x.Completed)
                    {
                        TrueList.Add(x);
                        PossativeList.Items.Add(x.Title);
                    }
                    else
                    {
                        FalseList.Add(x);
                        NegativeList.Items.Add(x.Title);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure you have a active internet connection then retrying", "No internet Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SortDataBut_Click(object sender, RoutedEventArgs e)
        {
            clearlists();

            TrueList =  TrueList.OrderBy(x => x.Title).ToList<CheckListDataModel>();
            TrueList.ForEach(x => PossativeList.Items.Add(x.Title));

            FalseList =  FalseList.OrderBy(x => x.Title).ToList<CheckListDataModel>();
            FalseList.ForEach(x => NegativeList.Items.Add(x.Title));
        }

        private void ComicsPageNavBut_Click(object sender, RoutedEventArgs e)
        {
            programRunning = true;
            StartPage startPage = new StartPage();
            startPage.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!programRunning)
            {
                Application.Current.Shutdown();
            }
        }
        /// <summary>
        /// clears the UI lists
        /// </summary>
        private void clearlists()
        {
            PossativeList.Items.Clear();
            NegativeList.Items.Clear();
        }
    }
}
