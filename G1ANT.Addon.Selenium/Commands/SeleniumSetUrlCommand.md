# selenium.seturl

## Syntax

```G1ANT
selenium.seturl url ⟦text⟧ nowait ⟦bool⟧
```

## Description

This command navigates the currently active selenium instance or tab to a specified URL address.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`url`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no|  | Webpage address to be loaded |
|`nowait` | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no | false | By default, waits until the webpage fully loads              |
| `if`           | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutselenium](G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutSeleniumVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](G1ANT.Manual/appendices/common-arguments.md) page.

## Example

This simple script opens Google in Chrome, then adds a new tab that starts opening NASA website and immediately — because of the `nowait true` argument — goes to G1ANT site:

```G1ANT
selenium.open chrome url google.com
selenium.newtab https://www.nasa.gov nowait true
selenium.seturl g1ant.com
```
