$driverFolder = ".\drivers"
$tmpFolder = ".\drivers\_tmp"
$chromeDriverLimit = 3
if (Test-Path $tmpFolder)
{
	Remove-Item $tmpFolder -Recurse
}

function Download-Chrome-Drivers
{
	$lastChromeDriver = Extract-Version (Invoke-webrequest -URI "https://chromedriver.storage.googleapis.com/LATEST_RELEASE").Content
	if ($lastChromeDriver[0] -ne '')
	{
		Remove-Item "$driverFolder\chromedriver*.exe"
		$lastChromeMajorVersion = $lastChromeDriver[1]
		for ($idx = 0; $idx -lt $chromeDriverLimit; $idx++)
		{
			$majorVersion = $lastChromeMajorVersion - $idx
			$chromeDriverVersion = (Invoke-webrequest -URI "https://chromedriver.storage.googleapis.com/LATEST_RELEASE_$majorVersion").Content
			
			Write-Host "Downloading Chrome driver: $chromeDriverVersion"
			$url = "https://chromedriver.storage.googleapis.com/$chromeDriverVersion/chromedriver_win32.zip"
			$outFile = "$driverFolder\chromedriver_win32_$chromeDriverVersion.zip"
			Start-BitsTransfer -Source $url -Destination $outFile 
			
			Expand-Archive $outFile -DestinationPath $driverFolder
			Rename-Item "$driverFolder\chromedriver.exe" "chromedriver_$chromeDriverVersion.exe"
			Remove-Item $outFile
		}
	}
}

function Load-Power-Html
{
    if (-not (Get-Module -ErrorAction Ignore -ListAvailable PowerHTML))
    {
        Write-Host "Installing PowerHTML module"
        Install-Module PowerHTML -Scope CurrentUser -ErrorAction Stop
    }
    Import-Module -ErrorAction Stop PowerHTML
}

function Extract-Version ($text)
{
	if ($text -match '(\d+)\.?(\d+)\.?(\d+)?\.?(\d+)?')
	{
		return $matches
	}
	return "";
}

function Download-And-Extract-Edge ($version)
{
	Write-Host "Downloading Edge drivers"$version[0]
	$ver = $version[0]
	@("32", "64") | foreach {
		$null = New-Item -Path $tmpFolder -ItemType Directory
		$url = "https://msedgedriver.azureedge.net/"+$version[0]+"/edgedriver_win"+$_+".zip"
		$outFile = "$tmpFolder\edgedriver_win"+$_+"_$ver.zip"
		Start-BitsTransfer -Source $url -Destination $outFile 
		
		Expand-Archive $outFile -DestinationPath $tmpFolder
		$filename = "$driverFolder\msedgedriver_"+$_+"_$ver.exe"
		Move-Item "$tmpFolder\msedgedriver.exe" $filename
		Remove-Item $tmpFolder -Recurse
	}
}

function Download-Edge-Drivers
{
	Remove-Item "$driverFolder\msedgedriver*.exe"
	
	$wc = New-Object System.Net.WebClient
	$res = $wc.DownloadString("https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/")
	$html = ConvertFrom-Html -Content $res
	$stableChannel = $html.SelectNodes("//*[@id='webdriver']//*[@aria-label='Microsoft Edge Driver for stable channel']")
	$download = $stableChannel[0].SelectNodes("..//*[@class='driver-download__meta']")
	
	$lastVersion = Extract-Version $download[0].innerText
	if ($lastVersion[0] -ne '')
	{
		Download-And-Extract-Edge $lastVersion
		
		$recentVersions = $html.SelectNodes("//*[@id='downloads']//*[@class='module']//*[@class='driver-download__meta'][position()=1]")
		$recentVersions | foreach {
			$ver = Extract-Version $_.innerText
			if ([int]$ver[1] -lt [int]$lastVersion[1])
			{
				Download-And-Extract-Edge $ver
			}
		}
	}
}

function Download-Gecko-Drivers
{
	Remove-Item "$driverFolder\geckodriver*.exe"

	$wc = New-Object System.Net.WebClient
	$res = $wc.DownloadString("https://github.com/mozilla/geckodriver/releases")
	$html = ConvertFrom-Html -Content $res

	$nodes = $html.SelectNodes("//*[@id='repo-content-pjax-container']//*[@class='Box']//*[contains(@href, '/mozilla/geckodriver/releases/tag/')]")
	
	$null = New-Item -Path $tmpFolder -ItemType Directory
	for ($idx = 0; ($idx -lt 1) -and ($idx -lt $nodes.count); $idx++)
	{
		$version = $nodes[$idx].innerText
		Write-Host "Downloading Gecko drivers"$version
		@("32", "64") | foreach {
			$url = "https://github.com/mozilla/geckodriver/releases/download/v"+$version+"/geckodriver-v"+$version+"-win"+$_+".zip"
			$outFile = "$tmpFolder\geckodriver-v"+$version+"-"+$_+".zip"
			Start-BitsTransfer -Source $url -Destination $outFile 

			Expand-Archive $outFile -DestinationPath $tmpFolder
			$filename = "$driverFolder\geckodriver_"+$_+"_$version.exe"
			Move-Item "$tmpFolder\geckodriver.exe" $filename
		}
	}
	Remove-Item $tmpFolder -Recurse
}

Load-Power-Html
Download-Chrome-Drivers
Download-Edge-Drivers
Download-Gecko-Drivers

Write-Host
Write-Host "Reload Selenium project in your Visual Studio NOW!"
Write-Host "Press any key to continue..."
$Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
