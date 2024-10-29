using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AhorcadoUiTest.StepDefinitions
{
    [Binding]
    public sealed class HangmanStepDefinitions
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void TestInitialize()
        {
            _driver = new ChromeDriver
            {
                Url = "http://localhost:5000/"
            };
        }


        [Given(@"The game has been initialized")]
        // No se puede especificar la palabra inicial ya que es elegida aleatoriamente de una lista de palabras disponibles.
        public void GivenTheGameHasBeenInitialized()
        {
            var btnJugar = _driver.FindElement(By.Id("btnJugar"));
            btnJugar.SendKeys(Keys.Enter);
        }

        [When(@"The user inputs the letter one random letter")]
        public void WhenIInputTheLetterA()
        {
            var txtLetra = _driver.FindElement(By.Id("txtLetra"));
            var btnProbar = _driver.FindElement(By.Id("btnProbar"));

            txtLetra.SendKeys("a");
            btnProbar.SendKeys(Keys.Enter);
        }

        [Then(@"The user should see the inputed letter")]
        public void ThenIShouldBeToldTheResult()
        {
            var lblLetrasIngresadas = _driver.FindElement(By.Id("lblLetrasIngresadas"));

            Assert.Contains("a", lblLetrasIngresadas.Text);
        }
    }
}