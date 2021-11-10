using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using G1ANT.Language;

namespace G1ANT.Addon.Selenium.Api
{
    public class SeleniumDriverResourceDescription
    {
        private string DriverName;
        private string ResourceName32;
        private string ResourceName64;

        public SeleniumDriverResourceDescription(string driverName, string resourceName)
        {
            Init(driverName, resourceName, resourceName);
        }

        public SeleniumDriverResourceDescription(string driverName, string resourceName32, string resourceName64)
        {
            Init(driverName, resourceName32, resourceName64);
        }

        public void UnpackIfNeeded(Assembly assembly, string unpackFolder)
        {
            var resourceName = Environment.Is64BitOperatingSystem ? ResourceName64 : ResourceName32;
            var resourceBinary = assembly.GetResourceBytes(resourceName);

            if (resourceBinary == null)
                throw new ApplicationException($"Driver '{resourceName}' is not embedded in the Addon.Selenium.");
            if (DriverNeedsUpdate(DriverName, resourceBinary, unpackFolder))
            {
                UpdateDriverFromResource(DriverName, resourceBinary, unpackFolder);
            }
        }

        private void Init(string driverName, string resourceName32, string resourceName64)
        {
            DriverName = driverName;
            ResourceName32 = resourceName32;
            ResourceName64 = resourceName64;
        }

        private bool DriverNeedsUpdate(string filename, byte[] resourceData, string unpackFolder)
        {
            return !DoesFileExist(unpackFolder, filename) || !AreFilesOfTheSameLength(resourceData.Length, unpackFolder, filename);
        }

        private void UpdateDriverFromResource(string filename, byte[] resourceData, string unpackFolder)
        {
            KillWorkingProcess(Path.GetFileNameWithoutExtension(filename));
            using (FileStream stream = File.Create(Path.Combine(unpackFolder, filename)))
            {
                stream.Write(resourceData, 0, resourceData.Length);
            }
        }

        private void KillWorkingProcess(string processName)
        {
            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                try
                {
                    proc.Kill();
                }
                catch
                {

                }
            }
        }

        private bool DoesFileExist(string folder, string fileName)
        {
            return File.Exists(Path.Combine(folder, fileName));
        }

        private bool AreFilesOfTheSameLength(int length, string folder, string fileName)
        {
            return length == new FileInfo(Path.Combine(folder, fileName)).Length;
        }
    }
}
