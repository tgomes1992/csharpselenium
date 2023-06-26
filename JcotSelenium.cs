using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace csharpselenium
{
    public class JcotSelenium
    {


        public IWebDriver driver = new ChromeDriver();

        public string user;

        public string password;


        public JcotSelenium()
        {


            this.driver.Navigate().GoToUrl("https://oliveiratrust.totvs.amplis.com.br/jcotapp/Html/#");


        }

        public void Login()
        {


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);



            var user = this.driver.FindElement(By.Id("userItem"));
            var password = this.driver.FindElement(By.Id("passItem"));
            var btn = this.driver.FindElement(By.Id("btlogin"));
            
            
            user.SendKeys(this.user);
            password.SendKeys(this.password);

            Thread.Sleep(2000);


            password.SendKeys(Keys.Enter);


            btn.Submit();

            Thread.Sleep(2000);


            var sbmt  = this.driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/button/span"));

            sbmt.Click();

        }


        public void LncMovimento()
        {

            // método que realiza o lancamento de movimentos

            this.Login();

            Thread.Sleep(3000);


            var link1 = this.driver.FindElement(By.XPath("//*[@id=\"menutree\"]/div/div/ul/li[2]/span"));

            link1.Click();


            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));

            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//*[@id=\"menutree\"]/div/div/ul/li[2]/ul/li[17]/span")));


            var link2 = this.driver.FindElement(By.XPath("//*[@id=\"menutree\"]/div/div/ul/li[2]/ul/li[17]/span"));

            link2.Click();


            var link3 = this.driver.FindElement(By.XPath("//*[@id=\"menutree\"]/div/div/ul/li[2]/ul/li[17]/ul/li[1]/span"));

            link3.Click();


            Thread.Sleep(2000);

            var link4  = this.driver.FindElement(By.XPath("//*[@id=\"menutree\"]/div/div/ul/li[2]/ul/li[17]/ul/li[1]/ul/li[3]/span/a"));

            link4.Click();


            this.driver.Manage().Window.Maximize();


            var data = this.driver.FindElement(By.Name("dt_amortizacao"));

            var cd_fundo = this.driver.FindElement(By.Name("cd_fundo"));

            var btn_filtro = this.driver.FindElement(By.Id("pdcaf_dwb_buscar"));

            data.SendKeys("23/06/2023");  // data do evento  

            cd_fundo.SendKeys("10961_MEZA"); //  cd_fundo


            btn_filtro.Click(); 

            Thread.Sleep(2000);




            // Registro do PU do evento ,
            // essa parte pode variar se vai sere por pu , por valor bruto ou por valor liquido

            //o 

            var pu = this.driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/form/div/div[2]/div/div[4]/div[3]/div/div/div[8]"));

            pu.Click();
            
            var pu2 = pu.FindElement(By.TagName("input"));
                      
            pu2.Click();

            pu2.SendKeys("150.000000");

            Thread.Sleep(50000);

            //var pu2 = this.driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/form/div/div[2]/div/div[4]/div[3]/div/div/div[8]/input"));

            //pu2.SendKeys("10.0");





        }






    }
}
