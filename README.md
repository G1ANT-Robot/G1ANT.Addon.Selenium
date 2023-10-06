# G1ANT.Addon.Selenium

## Update drivers instruction

### geckodriver

Download latest _MS Windows_ [geckodriver release](https://github.com/mozilla/geckodriver/releases), unpacke them and save in the **Resources** folder of the project as **geckodriver-32.exe** and **geckodriver-64.exe** files.

## Selenium drivers to download

Suggesstion: Having said the above, if you use latest selenium version v4.12.0, you do not have to worry about downloading the chromedriver manually, selenium's new in-built tool Selenium Manager will download and manage the drivers for you automatically.

Code to launch browser can be as simple as:

```python
from selenium import webdriver

driver = webdriver.Chrome()
driver.get("https://www.google.com/")
```

Few references:
* [Selenium drivers for download](https://googlechromelabs.github.io/chrome-for-testing/#stable)
* [Introducing Selenium Manager](https://www.selenium.dev/blog/2022/introducing-selenium-manager/)
* [Stackoverflow](https://stackoverflow.com/a/76463081/7598774)
