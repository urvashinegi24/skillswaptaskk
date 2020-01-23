using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using SpecflowPages.Utils;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Driver.waitVisiblity(driver, "XPath", "/html/body/div[2]/div/div");
            
            LoginPage loginPage = new LoginPage();
            loginPage.profileclick();

        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                while (true)
                {
                    for (var i = 1; i <= 4; i++)
                    {
                        string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody["+ i +"]/tr/td[1]")).Text;
                        Thread.Sleep(500);
                        if (ExpectedValue == ActualValue)
                        {
                          CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                            Assert.IsTrue(true);
                            return;                          
                      }
                    }
                }


        }
        [Given(@"I have logged into skillswap portal Navigate to Profile tab")]
        public void GivenIHaveLoggedIntoSkillswapPortalNavigateToProfileTab()
        {
            //Wait
            Thread.Sleep(1500);
            LoginPage loginPage = new LoginPage();
            loginPage.profileclick();
        }

        [When(@"change first and last name")]
        public void WhenChangeFirstAndLastName()
        {
            //Click on dropdown button
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
            //Add First Name
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]")).Clear();
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]")).SendKeys("UpdateTest");
            //Add Last Name
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]")).Clear();
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]")).SendKeys("Testing12");
            //Click on Save
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button")).Click();
        }

        [Then(@"the changes should be displayed")]
        public void ThenTheChangesShouldBeDisplayed()
        {
            //Click on dropdown button
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
            Thread.Sleep(1500);
            //check first name and Last name

            string FirstName = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]")).GetAttribute("value");
            string LastName = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]")).GetAttribute("value");
            if ((FirstName == "UpdateTest") && (LastName == "Testing12"))
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a First & Last Name Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "First and Last Name Addeed");
                Assert.IsTrue(true);

            }
        }
        [When(@"I add firstname,last name and language \\\.")]
        public void WhenIAddFirstnameLastNameAndLanguage_()
        {
            //Click on dropdown button
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
            //Add First Name
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]")).Clear();
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]")).SendKeys("ViewTest");
            //Add Last Name
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]")).Clear();
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]")).SendKeys("CheckingView");
            //Click on Save
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button")).Click();
            Thread.Sleep(1500);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            
            
            //Add Language

            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("Spain");

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();



            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
        }
              

        [Then(@"Log out and login again\. Already created profile is displayed")]
        public void ThenLogOutAndLoginAgain_AlreadyCreatedProfileIsDisplayed()
        {
            Driver.driver.FindElement(By.XPath("/ html / body / div[1] / div / div[1] / div[2] / div / a[2] / button")).Click();
            Thread.Sleep(1500);
            LoginPage loginPage = new LoginPage();
            loginPage.LoginStep();
            loginPage.profileclick();
             //Click on dropdown button
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
            string FirstName = Driver.driver.FindElement(By.XPath(" / html / body / div[1] / div / section[2] / div / div / div / div[2] / div / div / div / div / div / div[2] / div / div / div[2] / div / div[1] / input[1]")).GetAttribute("value");
            string LastName = Driver.driver.FindElement(By.XPath(" / html / body / div[1] / div / section[2] / div / div / div / div[2] / div / div / div / div / div / div[2] / div / div / div[2] / div / div[1] / input[2]")).GetAttribute("value");

            string Language = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[1]")).Text;
            string LanguageLevel = Driver.driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / table / tbody / tr / td[2]")).Text;

            if ((FirstName == "ViewTest") && (LastName == "CheckingView") && (Language =="Spain") && (LanguageLevel =="Basic"))
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Profile Viewed Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Profile viewed successfully ");
                Assert.IsTrue(true);
                return;
            }
            
        }
        [Given(@"I clicked on the Skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            Driver.waitVisiblity(driver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
            //Click on Skill tab
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();
        }

        [When(@"I add a new Skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Add new
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //Enter Skill
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).SendKeys("Automation");
            //Choose the Skill level

            Driver.driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option"))[2].Click();
 
            //Click on Add Skill
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
        }

        [Then(@"that Skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

            Thread.Sleep(1000);
            string ExpectedValue = "Automation";
            while (true)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Thread.Sleep(500);
                    string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody["+ i +"]/tr/td[1]")).Text;
                    
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill");
                        Assert.IsTrue(true);
                        return;
                    }
                }
            }
        }
        [When(@"I click on language to click on edit button for already added language")]
        public void WhenIClickOnLanguageToClickOnEditButtonForAlreadyAddedLanguage()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill");
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");
            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
            Thread.Sleep(1000);
            string ExpectedValue = "English";
            while (true)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Thread.Sleep(500);
                    string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                   
                    if (ExpectedValue == ActualValue)
                    {
                        //Click on edit button
                        Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i")).Click();
                        //Clear language
                        Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input")).Clear();
                        //Add Language
                        Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input")).SendKeys("Hindi");
                        //Choose the language level
                        Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[3].Click();
                        //Click on Update button
                        Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")).Click();
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated the Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageEdited");
                        Assert.IsTrue(true);
                        return;
                    }
                }
            }

        }

        [When(@"I click on language tab and then click on delete button for already added language")]
        public void WhenIClickOnLanguageTabAndThenClickOnDeleteButtonForAlreadyAddedLanguage()
        {
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Deleted a Language");
            Thread.Sleep(1000);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");
            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
            string ExpectedValue = "English";
            while (true)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Thread.Sleep(1500);
                    string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    
                    if (ExpectedValue == ActualValue)
                    {
                        //Click on delete button
                        Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i +"]/tr/td[3]/span[1]")).Click();
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted the Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                        Assert.IsTrue(true);
                        return;
                    }
                }
            }
        }

        [Then(@"the changes for language made should be displayed successfully")]
        public void ThenTheChangesForLanguageMadeShouldBeDisplayedSuccessfully()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");

            Thread.Sleep(1000);
            string ExpectedValue = "Hindi";
            while (true)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Thread.Sleep(500);
                    string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Update a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                        Assert.IsTrue(true);
                        return;
                    }
                }
            }
        }

        [Then(@"language should be deleted successufully")]
        public void ThenLanguageShouldBeDeletedSuccessufully()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

            Thread.Sleep(1000);
            string ExpectedValue = "English";
            while (true)
            {
                for (var i = 1; i <= 4; i++)
                {
                   String  ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Language Not Deleted");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageNotDeleted");
                        Assert.IsFalse(true);   
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                        Assert.IsTrue(true);
                        return;
                    }
                }
            }
        }
    }

    

}


    


