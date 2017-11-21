using G1ANT.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.waitforvalue", Tooltip = "Waits for javascript code to return specified value.")]
    public class SeleniumWaitForValueCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Pass the full script as string to get it evaluated in browser")]
            public TextStructure Script { get; set; }

            [Argument(Required = true, Tooltip = "Value what we expect that script will return")]
            public TextStructure ExpectedValue { get; set; }

            [Argument(DefaultVariable = "timeoutie", Tooltip = "Specifies maximum number of milliseconds to wait for browser to get expected value")]
            public override int Timeout { get; set; } = (SeleniumSettings.SeleniumTimeout);
                    }
        public SeleniumWaitForValueCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            int timeout = arguments.Timeout;
            int start = Environment.TickCount;
            string result = string.Empty;
            SeleniumWrapper seleniumWrapper = SeleniumManager.CurrentWrapper;
            try
            {
                while (Math.Abs(Environment.TickCount - start) < timeout &&
                            //ShouldStopScript() == false && //TODO coś
                            result.ToLower() != arguments.ExpectedValue?.Value?.ToLower())
                {
                    try
                    {
                        result = seleniumWrapper.RunScript(arguments.Script.Value);
                    }
                    catch
                    {
                        // JavaScript exception occured but we don't really care
                        // maybe element did not exist and we got exception cause of that
                    }
                    Application.DoEvents();
                }
                if (result.ToLower() != arguments.ExpectedValue.Value?.ToLower())
                {
                    throw new TimeoutException("Timeout occured while waiting for an element. Specified element was not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while running javascript script: '{arguments.Script.Value}'. Returned result: '{result}'. Message: {ex.Message}", ex);
            }
        }
    }
}
