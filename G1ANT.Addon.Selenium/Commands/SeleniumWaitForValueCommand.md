# selenium.waitforvalue

**Syntax:**

```G1ANT
selenium.waitforvalue  script ‴‴  expectedvalue ‴‴
```

**Description:**

Command `selenium.waitforvalue` waits for javascript code to return specified value.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`script`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | pass the full script as string to get it evaluated in browser |
|`expectedvalue`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | value that we expect script will return |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

`selenium.waitforvalue` lets us check if the element on the web page is fully loaded so that G1ANT.Robot can perform further actions. It is useful when you want to make sure that certain element is already loaded before you start typing inside of it.

```G1ANT
selenium.open type ‴chrome‴ url ‴google.com‴
selenium.waitforvalue script ‴return document.querySelectorAll('#lst-ib').length &gt; 0‴ expectedvalue ‴true‴ timeout 20000
selenium.type text ‴fluffy robots‴ search ‴lst-ib‴ by ‴id‴
selenium.close
```
