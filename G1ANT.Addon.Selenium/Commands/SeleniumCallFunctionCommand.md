# selenium.callfunction

**Syntax:**

```G1ANT
selenium.callfunction  functionname ‴‴ search ‴‴
```

**Description:**

Command `selenium.callfunction` calls function on specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`functionname`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | name of function to call |
|`search`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | phrase to find element by |
|`parameters`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | parameters to be passed to the function |
|`type`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | function call type, either ‴javascript‴ or ‴jquery‴ |
|`by`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | specifies an element, accepts 'name','text','title','class','id','selector','query','jquery' |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

```G1ANT
selenium.open type ‴chrome‴ url ‴msn.com‴ timeout 30000
list.create text ‴aa‴ result ♥list
selenium.callfunction search ‴q‴ by ‴id‴ functionname ‴val‴ parameters ♥list type ‴jquery‴
selenium.runscript script ‴return $('#q').val();‴ result ♥result
dialog ♥result
```
