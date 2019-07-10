# selenium.callfunction

## Syntax

```G1ANT
selenium.callfunction functionname ⟦text⟧ parameters ⟦text⟧ type ⟦text⟧ search ⟦text⟧ by ⟦text⟧ iframesearch ⟦text⟧ iframeby ⟦text⟧
```

## Description

This command calls a function on a specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`functionname`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Name of a function to call |
|`parameters`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Parameters to be passed to the function |
|`type`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Function call type: `javascript` or `jquery` |
|`search`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Phrase to find an element by |
|`by`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Specifies an element selector: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery` |
|`iframesearch`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Phrase to find an iframe by |
|`iframeby`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Specifies an iframe selector: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery` |
| `if`           | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                         | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutselenium](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutSeleniumVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                              | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                              | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                              | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                              | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

> **Note:** the `selenium.` commands require opening a browser with the `selenium.open` command first, and they refer to the browser’s first tab by default. If you have more tabs opened and want to use the `selenium.` commands on a tab other than the first one, use the `selenium.activatetab` command to change the active tab.

## Example

```G1ANT
selenium.open chrome url msn.com timeout 30000
list.create text aa result ♥list
selenium.callfunction search q by id functionname val parameters ♥list type jquery
selenium.runscript script ‴return $('#q').val();‴
dialog ♥result
```
