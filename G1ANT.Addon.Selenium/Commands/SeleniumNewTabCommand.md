# selenium.newtab

**Syntax:**

```G1ANT
selenium.newtab
```

**Description:**

Command `selenium.newtab` creates new tab in current browser.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`url`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no|  | webpage address to load |
|`nowait` | [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | false | waits until the web page fully loads |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

In order to check how this command works, we should open the browser first, then open a few new tabs using  `selenium.newtab` command.

```G1ANT
selenium.open type ‴firefox‴ url ‴wp.pl‴ result ♥wp
 selenium.newtab url ‴facebook.com‴
 selenium.newtab url ‴google.com‴
```

**Example 2:**

In this example you can see that the browser initially waits until ‴http://www.bbc.com/news‴ loads (default value is false, so G1ANT.Robot waits until the webpage fully loads) and then G1ANT.Robot opens ‴https://www.theguardian.com/international‴ without waiting for ‴amazon.com‴ to fully load.

```G1ANT
selenium.open type ‴firefox‴ url ‴http://www.bbc.com/news‴
selenium.newtab url ‴amazon.com‴ nowait true
selenium.newtab url ‴https://www.theguardian.com/international‴
selenium.activatetab search ‴bbc‴ by ‴url‴
```
