using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow.Utilities
{
    [Binding]
    class ExtentReport
    {
        static AventStack.ExtentReports.ExtentReports extent;

        [ThreadStatic]
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;

        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "TestLibrary/TestReports"
            + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + Path.DirectorySeparatorChar;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreport);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeSceanrio(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                string base64 = GlobalDefinitions.GetScreenshot();
                step.Log(Status.Fail, context.StepContext.StepInfo.Text,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                CommonDriver.driver.Quit();
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
