using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AhorcadoUiTest.StepDefinitions;

[Binding]
public class AhorcadoStepDefinitions
{
    private IWebDriver? _driver;
    private readonly string _driverUrl = "http://localhost:5299";
    
    [BeforeScenario]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArguments("--headless", "--no-sandbox", "--disable-dev-shm-usage");
    
        _driver = new ChromeDriver(options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [AfterScenario]
    public void TearDown()
    {
        _driver?.Quit();
    }
    
    [Given(@"I navigate to the game page with word ""(.*)""")]
    public void GivenINavigateToTheGamePageWithWord(string word)
    {
        _driver?.Navigate().GoToUrl($"{_driverUrl}/{word}");
    }

    [When(@"I enter the letter ""(.*)""")]
    public void WhenIEnterTheLetter(string letter)
    {
        var charInput = _driver?.FindElement(By.Id("charInput"));
        var tryBtn = _driver?.FindElement(By.Id("tryBtn"));
        
        charInput?.SendKeys("a");
        tryBtn?.Click();
    }
    
    [When(@"I incorrectly enter the letter ""(.*)""")]
    public void WhenIIncorrectlyEnterTheLetter(string letter)
    {
        var charInput = _driver?.FindElement(By.Id("charInput"));
        var tryBtn = _driver?.FindElement(By.Id("tryBtn"));
            
        charInput?.Clear();
        charInput?.SendKeys(letter);
        tryBtn?.Click();
    }
    
    [When(@"I enter the word ""(.*)""")]
    public void WhenIEnterTheWord(string word)
    {
        var wordInput = _driver?.FindElement(By.Id("wordInput"));
        var guessBtn = _driver?.FindElement(By.Id("guessBtn"));

        wordInput?.SendKeys(word);
        guessBtn?.Click();
    }

    [Then(@"I should see the message ""(.*)""")]
    public void ThenIShouldSeeTheMessage(string expectedMessage)
    {
        var outputMsg = _driver?.FindElement(By.Id("outputMsg")).Text;
        
        Assert.True(outputMsg?.Contains(expectedMessage), $"Expected message to contain '{expectedMessage}', but got '{outputMsg}'.");
    }
    
}