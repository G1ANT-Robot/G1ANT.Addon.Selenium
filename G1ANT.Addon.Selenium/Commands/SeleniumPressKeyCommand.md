# selenium.presskey

## Syntax

```G1ANT
selenium.presskey key ⟦text⟧ search ⟦text⟧ by ⟦text⟧ iframesearch ⟦text⟧ iframeby ⟦text⟧
```

## Description

This command sends a keystroke into a specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`key`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |   | Key to be pressed |
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

The script below opens DuckDuckGo search engine in Chrome, then enters “*whale sharks*” search phrase into the search box (an element found by its ID named `search_form_input_homepage`). After a 2-second delay the robot simulates pressing **Enter** key on the search button (ID: `search_button_homepage`):

```G1ANT
selenium.open chrome url duckduckgo.com
selenium.type ‴whale sharks‴ search search_form_input_homepage by id
delay 2
selenium.presskey enter search search_button_homepage by id
```

> **Note:** The element could also be searched by other selectors: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery`. In order to search any element on a website using the `selenium.presskey` command, you need to use web browser developer tools (right-click an element and select `Inspect element` or `Inspect` from the resulting context menu).