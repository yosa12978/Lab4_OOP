using StressTest;
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

namespace TestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            materials.ItemsSource = Enum.GetValues(typeof(Material));
            crosssections.ItemsSource = Enum.GetValues(typeof(CrossSection));
            testresults.ItemsSource = Enum.GetValues(typeof(TestResult));
            
            materials.SelectedIndex = 0;
            crosssections.SelectedIndex = 0;
            testresults.SelectedIndex = 0;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Material? selectedMaterial = (Material?)materials.SelectedItem;
            CrossSection? selectedCrossSection = (CrossSection?)crosssections.SelectedItem;
            TestResult? selectedTestResult = (TestResult?)testresults.SelectedItem;
            //results.Text = $"You selected {selectedMaterial}, {selectedCrossSection}, and {selectedTestResult}.";
            StringBuilder selectionStringBuilder = new StringBuilder();

            switch (selectedMaterial)
            {
                case Material.StainlessSteel:
                    selectionStringBuilder.Append("Material: Stainless Steel\n\r");
                    break;
                case Material.Aluminum:
                    selectionStringBuilder.Append("Material: Aluminum\n\r");
                    break;
                case Material.ReinforcedConcrete:
                    selectionStringBuilder.Append("Material: Reinforced Concrete\n\r");
                    break;
                case Material.Titanium:
                    selectionStringBuilder.Append("Material: Titanium\n\r");
                    break;
                case Material.Composite:
                    selectionStringBuilder.Append("Material: Composite\n\r");
                    break;
                default:
                    selectionStringBuilder.Append("Material: Unknown\n\r");
                    break;
            }

            switch (selectedCrossSection)
            {
                case CrossSection.IBeam:
                    selectionStringBuilder.Append("Cross Section: I-Beam\n\r");
                    break;
                case CrossSection.Box:
                    selectionStringBuilder.Append("Cross Section: Box\n\r");
                    break;
                case CrossSection.ZShaped:
                    selectionStringBuilder.Append("Cross Section: Z-Shaped\n\r");
                    break;
                case CrossSection.CShaped:
                    selectionStringBuilder.Append("Cross Section: C-Shaped\n\r");
                    break;
                default:
                    selectionStringBuilder.Append("Cross Section: Unknown\n\r");
                    break;
            }

            switch (selectedTestResult)
            {
                case TestResult.Pass:
                    selectionStringBuilder.Append("Test Result: Pass");
                    break;
                case TestResult.Fail:
                    selectionStringBuilder.Append("Test Result: Fail");
                    break;
                default:
                    selectionStringBuilder.Append("Test Result: Unknown");
                    break;
            }

            results.Text = selectionStringBuilder.ToString();
        }

        private void RunTests_Click(object sender, RoutedEventArgs e)
        {
            reasonsList.Items.Clear();
            TestCaseResult[] testResults = new TestCaseResult[10];
            for (int i = 0; i < testResults.Length; i++)
                testResults[i] = GenerateResult();
            int passCount = 0;
            int failCount = 0;
            for (int i = 0; i < testResults.Length; i++)
            {
                switch (testResults[i].Result)
                {
                    case TestResult.Pass:
                        passCount++;
                        break;
                    case TestResult.Fail:
                        failCount++;
                        reasonsList.Items.Add(testResults[i].ReasonForFailure);
                        break;
                }
            }
        }

        private TestCaseResult GenerateResult()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int choice = random.Next(4);
            switch(choice)
            {
                case 0:
                    return new TestCaseResult(TestResult.Fail, "Error 1");
                case 1:
                    return new TestCaseResult(TestResult.Fail, "Error 2");
                case 2:
                    return new TestCaseResult(TestResult.Fail, "Error 3");
                default:
                    return new TestCaseResult(TestResult.Pass, "");
            }
        }
    }
}
