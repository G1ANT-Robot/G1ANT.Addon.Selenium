# selenium.seturl

**Syntax:**

```G1ANT
selenium.seturl
```

**Description:**

Command `selenium.seturl` navigates currently active selenium instance to specified url.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`url`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no|  | web page address to be loaded |
|`nowait` | "nowait":{TOPIC-LINK+boolean}| no | false | waits until the webpage fully loads |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

```G1ANT
selenium.open type ‴firefox‴ url ‴google.com‴
selenium.newtab url ‴https://www.nasa.gov‴ nowait true
selenium.seturl url ‴www.esa.int‴
```
