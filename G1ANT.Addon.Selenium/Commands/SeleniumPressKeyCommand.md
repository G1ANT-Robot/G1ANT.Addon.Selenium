# selenium.presskey

**Syntax:**

```G1ANT
selenium.presskey  key ‴‴  search ‴‴
```

**Description:**

Command `selenium.presskey` types text into element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`key`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |   | key to press |
|`search`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |   | phrase to find element by |
|`by`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | specifies an element selector, accepts 'name','text','title','class','id','selector','query','jquery' |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

`selenium.presskey` is an advanced search command that enables to find certain element on a webpage by 'name','text','title','class','id','selector','query','jquery'. When it finds the element, it performs certain action on it by pressing a key you choose.

```G1ANT
selenium.open type ‴firefox‴ url ‴duckduckgo.com‴
 selenium.type text ‴whale sharks‴ search ‴search_form_homepage‴ by ‴id‴
 selenium.presskey key ‴enter‴ search ‴search_button_homepage‴ by ‴id‴
```

First open a browser using `selenium.open` command.
Then use `selenium.type` command to  type a phrase you want to search - ‴whale sharks‴ and then find an element where the phrase will be typed ‴search_form_homepage‴. You can find the element using developer tools in your web browser. ‴whale sharks‴ will be typed inside of the search window that you chose by id.

The `selenium.open` command becomes handy now that you want to choose the 'search button' in the browser. Use developer tools in your web browser to choose the element and use it as the value for 'search' argument. Then type the 'key' argument. Usually you would use 'enter' as the value, but any button can be used. If you use 'enter' as in the example, G1ANT.Robot will press the search button for you automatically.

