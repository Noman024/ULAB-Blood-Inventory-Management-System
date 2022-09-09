using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ULABBloodInventoryManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("executeautomation");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DonorRegistration());
            //Application.Run(new DonorsList());
            //Application.Run(new PatientRegistration());
            //Application.Run(new PatientsList());
            //Application.Run(new DonateBlood());
            //Application.Run(new BloodStock());
            //Application.Run(new ReceiveBlood());
            //Application.Run(new Admin());
            //Application.Run(new Login());
            //Application.Run(new Dashboard());
            //Application.Run(new Mainform());
            Application.Run(new SplashWindow());

            driver.Close();
        }
    }
}
