using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SpecflowPages
{
    public class ConstantUtils
    {
        //Base Url
        public static string Url = "http://www.skillswap.pro/";
        

        //ScreenshotPath
         public static string ScreenshotPath = Environment.CurrentDirectory + @"\ScreenShots\";
        //ExtentReportsPath
        //public static string ReportsPath = @"C:\Users\urvashi\source\repos\SpecflowTests-Base\SpecflowTests\Test.html";
        //public static string ReportsPath = Environment.CurrentDirectory;
        //public static string ReportsPath = Environment.;
        public static string ReportsPath = Environment.CurrentDirectory;
        // public static string ReportsPath = System.IO.Directory.GetCurrentDirectory().Replace("\\SpecflowTests\\SpecflowTests\\bin\\Debug", "");
        //public static string ReportsPath2 = Application.StartupPath;

        //ReportXML Path
        public static string ReportXMLPath = Environment.CurrentDirectory + @"\ReportXML\";


    }
}
