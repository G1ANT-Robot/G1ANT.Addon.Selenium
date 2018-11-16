# selenium.setattribute

**Syntax:**

```G1ANT
selenium.setattribute  name ‴‴ search ‴‴
```

**Description:**

Command `selenium.setattribute` sets specified attribute of specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`name` | [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | name of attribute to set value of |
|`search` | [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | phrase to find element by |
|`value` | [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | value to set  |
|`by`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no | | specifies an element selector, accepts 'name','text','title','class','id','selector','query','jquery' |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutselenium](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Selenium.dll**.
See: [https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium](https://github.com/G1ANT-Robot/G1ANT.Addon.Selenium)

**Example 1:**

```G1ANT
selenium.open type ‴firefox‴ url ‴duckduckgo.com‴
selenium.setattribute name ‴class‴ value ‴hidden‴ search ‴logo_homepage_link‴ by ‴id‴
```

This command enables to search for certain element on a web page and set an attribute for it. In our example we are causing the logo disappear by setting a 'hidden' class for the logo.
To set an attribute we need to catch an element first. In order to do that, please check developer tools.

**search** argument expects the value of **by** argument, which could be 'id', 'class', etc. In our case the value of **search** argument is ‴logo_homepage_link‴
**name** argument expects 'class', 'id', etc. and **value** argument defines what should happen with the element that we catch. 
HTML tag for the logo is:
`&lt;a id = "logo_homepage_link" class = "logo_homepage" href = "/about"&gt;&lt;/a&gt;`

**Example 2:**

Other way of catching the same element is by 'class'.

```G1ANT
selenium.open type ‴firefox‴ url ‴duckduckgo.com‴
selenium.setattribute name ‴class‴ value ‴invisible‴ search ‴logo_homepage‴ by ‴class‴
```

**Example 3:**

```G1ANT
selenium.open type ‴firefox‴ url ‴duckduckgo.com‴
selenium.setattribute name ‴class‴ value ‴width:0‴ search ‴logo_homepage‴ by ‴class‴
```

**Example 4:**

```G1ANT
selenium.open type ‴chrome‴ url ‴duckduckgo.com‴
selenium.setattribute name ‴style‴ value ‴background-color: red;‴ search ‴search-wrap--home‴ by ‴class‴
```

This command will perform the same action as you could achive using jQuery `$(".search-wrap--home")[0].setAttribute("style", "background-color: red;")`
