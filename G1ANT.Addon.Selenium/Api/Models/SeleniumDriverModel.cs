using System;
using System.IO;
using System.Text.RegularExpressions;

namespace G1ANT.Addon.Selenium.Api.Models
{
    public class SeleniumDriverModel
    {
        public string FilePath { get; }
        public Version Version { get; }

        public SeleniumDriverModel(string path)
        {
            FilePath = path;
            Version = ExtractVersion(path);
        }

        private Version ExtractVersion(string path)
        {
            var name = Path.GetFileNameWithoutExtension(path);
            var match = Regex.Match(name, @"(.*)_((\d+)\.?(\d+)\.?(\d+)?\.?(\d+)?)");
            if (match.Success)
                try
                {
                    return new Version(match.Groups[2].Value);
                }
                catch
                { }
            return new Version();
        }
    }
}
