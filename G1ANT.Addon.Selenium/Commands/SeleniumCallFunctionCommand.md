# selenium.callfunction

## Syntax

```G1ANT
selenium.callfunction functionname ⟦text⟧ parameters ⟦text⟧ type ⟦text⟧ search ⟦text⟧ by ⟦text⟧ iframesearch ⟦text⟧ iframeby ⟦text⟧
```

## Description

This command calls a function on a specified element.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`functionname`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Name of a function to call |
|`parameters`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |  | Parameters to be passed to the function |
|`type`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Function call type: `javascript` or `jquery` |
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

```G1ANT
selenium.open chrome url msn.com timeout 30000
list.create text aa result ♥list
selenium.callfunction search q by id functionname val parameters ♥list type jquery
selenium.runscript script ‴return $('#q').val();‴
dialog ♥result
```
