# selenium.type

## Syntax

```G1ANT
selenium.type text ⟦text⟧ search ⟦text⟧ by ⟦text⟧ iframesearch ⟦text⟧ iframeby ⟦text⟧
```

## Description

This command types text into a specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`text`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |   | Text to be typed |
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

> **Note:** the `selenium.` commands require opening a browser with the `selenium.open` command first, and they refer to the browser’s first tab by default. If you have more tabs opened and want to use the `selenium.` commands on a tab other than the first one, use the `selenium.activatetab` command to change the active tab.

## Example

The following example opens DuckDuckGo search engine in Chrome, then types a “*robotic process automation*” phrase into the search field (the `search_form_input_homepage` element found by its ID) and clicks the search button (the `search_button_homepage` element found by its ID).

After a 3-second delay the robot adds a “ *g1ant*” phrase (with a leading white space) to the previous search phrase (note that the ID of the search field is a bit different now, since it’s not on the homepage: `search_form_input`) and simulates pressing **Enter** key on the search button:

```G1ANT
selenium.open chrome url duckduckgo.com
selenium.type ‴robotic process automation‴ search search_form_input_homepage by id
selenium.click search search_button_homepage by id
delay 3
selenium.type ‴ g1ant‴ search search_form_input by id
selenium.presskey enter search search_button by id
```
