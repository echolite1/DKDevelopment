using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace PayoneerScrap
{
    public partial class Form1 : Form
    {
        string USD = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("https://payoneer-ua.liberwing.com/");
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            //var driverlil = new PhantomJSDriver(driverService);
            //Thread.Sleep(10000);
            //((IJavaScriptExecutor)driver).ExecuteScript("window.stop();");
            //--------------------------------------------------------------------------------------------
            var rate = driver.FindElement(By.XPath("//*[@id=\"curs_pb\"]")).GetAttribute("innerHTML");
            var klocalka = driver.FindElement(By.XPath("//*[@id=\"toggleccources\"]"));
            klocalka.Click();
            var mcCustomRate = driver.FindElement(By.XPath("//*[@id=\"ccurs_mc\"]"));
            mcCustomRate.Clear();
            mcCustomRate.SendKeys(rate.ToString());
            var iSum = driver.FindElement(By.XPath("//*[@id=\"isum\"]"));
            iSum.Clear();
            USD = howmuch.Text;
            iSum.SendKeys(USD);
            var rMcUah = driver.FindElement(By.XPath("//*[@id=\"r_mc_grn\"]")).GetAttribute("innerHTML");
            //--------------------------------------------------------------------------------------------
            resultText.Text = rMcUah;
            rateText.Text = rate;
            if (Convert.ToDouble(rMcUah) > 20050)
                resultText.ForeColor = Color.Green;
            else resultText.ForeColor = Color.Red;
            //UPW.Text = Convert.ToString(Convert.ToInt32(howmuch.Text) + 6);
            //UPW.Text = Convert.ToString(Convert.ToInt32(UPW.Text) * 1.3);
            //clean.Text = Convert.ToString(Convert.ToInt32(howmuch.Text) * 0.965 - 3.15);
            driver.Quit();
        }
    }
}
