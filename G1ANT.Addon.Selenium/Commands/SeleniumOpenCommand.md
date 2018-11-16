# selenium.open

**Syntax:**

```G1ANT
selenium.open  type ‴mozilla‴
```

**Description:**

Command `selenium.open` opens new instance of chosen web browser and optionally navigates to specified url address.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`type`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes|  | name of the web browser |
|`url`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no|  | web page address to be loaded |
|`nowait` | "nowait":{TOPIC-LINK+boolean}| no | false | waits until the webpage fully loads  |
|`result` | [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | stores the result of the command in a variable |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

```G1ANT
selenium.open type ‴firefox‴ url ‴https://www.google.co.uk/search?q=g1ant‴
```

**Example 2:**

This example opens website and waits 5 seconds (using `delay` command) till it will be loaded, afterwards `keyboard` command emulates TAB key pressed two times then ENTER. Finally "http://irpaai.com/membership/" will be opened.

```G1ANT
selenium.open type ‴firefox‴ url ‴www.irpanetwork.com‴
delay 5
keyboard ⋘tab 2⋙⋘enter⋙
```
