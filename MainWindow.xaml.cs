using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;

namespace SalaryPartTwo
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Empl
        {
            public string Name;
            public string Job;
            public int Age;
            public double Salary;
            public bool IsMarried;
            public bool HasChildren;

            public Empl(string name, string job, int age, bool isMarried, bool hasChildren)
            {
                Name = name;
                Job = job;
                Age = age;
                IsMarried = isMarried;
                HasChildren = hasChildren;

                CalculateSalary();
            }

            private void CalculateSalary()
            {
                switch (Job)
                {
                    case "Driver":
                        Salary = 6000 * Age;
                        break;
                    case "Mechanic":
                        Salary = 5000 * Age;
                        break;
                    case "CS":
                        Salary = 4000 * Age;
                        break;
                }

                
                if (IsMarried)
                {
                    Salary *= 1.7;
                }
                if (HasChildren)
                {
                    Salary *= 1.3;
                }
                
                
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = EName.Text;
            string job = string.Empty;
            bool isMarried = IsMarried.IsChecked == true;
            bool hasChildren = HasChildren.IsChecked == true;


            if (Driver.IsChecked == true)
            {
                job = "Driver";
            }
            else if (Mechanic.IsChecked == true)
            {
                job = "Mechanic";
            }
            else if (CS.IsChecked == true)
            {
                job = "CS";
            }

            int age = Convert.ToInt32(EAge.Text);

            Empl empl1 = new Empl(name, job, age, isMarried, hasChildren);


            MessageBox.Show("Salary: " + empl1.Salary);
        }
    }
}