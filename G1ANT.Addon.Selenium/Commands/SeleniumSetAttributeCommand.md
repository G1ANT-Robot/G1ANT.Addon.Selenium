# selenium.setattribute

## Syntax

```G1ANT
selenium.setattribute name ⟦text⟧ value ⟦text⟧ search ⟦text⟧ by ⟦text⟧ iframesearch ⟦text⟧ iframeby ⟦text⟧
```

## Description

This command sets a specified attribute of a specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`name` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Name of an attribute to set its value |
|`value` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Value to set |
|`search`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Phrase to find an element by |
|`by`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Specifies an element selector: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery` |
|`iframesearch`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Phrase to find an iframe by |
|`iframeby`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Specifies an iframe selector: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery` |
| `if`           | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                         | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutselenium](G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutSeleniumVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                              | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                              | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                              | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                              | Name of a variable that will store the returned exception. The variable will be of [error](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](G1ANT.Manual/appendices/common-arguments.md) page.

## Example

The script below opens DuckDuckGo search engine in Chrome and after a 2-second delay it hides the site logo by setting an appropriate element’s attribute value to `hidden`:

```G1ANT
selenium.open chrome url duckduckgo.com
delay 2
selenium.setattribute class value hidden search logo_homepage_link by id
```

The HTML tag for the logo element is:

```html
</a id = "logo_homepage_link" class = "logo_homepage" href = "/about">
```

Therefore, you can also do the same trick by finding the logo element by its `class` and setting this class value to `invisible`:

```G1ANT
selenium.open chrome url duckduckgo.com
delay 2
selenium.setattribute class value invisible search logo_homepage by class
```

> **Note:** The element could also be searched by other selectors: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery`. In order to search any element on a website using the `selenium.setattribute` command, you need to use web browser developer tools (right-click an element and select `Inspect element` or `Inspect` from the resulting context menu).