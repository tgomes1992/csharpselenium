using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.CSS;
using OpenQA.Selenium.DevTools.V112.DOM;

namespace csharpselenium
{
    public class GoogleInteractions
    {


       public  IWebDriver driver = new ChromeDriver();


        public GoogleInteractions() {


            this.driver.Navigate().GoToUrl("https://www.google.com/");
            
       
        }

        public void FirstSearch()
        {

            var element_search =  this.driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/textarea"));

            element_search.SendKeys("Linkedin");

            Thread.Sleep(1000);

            element_search.SendKeys(Keys.Enter);


        }




    }
}
