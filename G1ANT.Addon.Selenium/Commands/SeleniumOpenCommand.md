# selenium.open

## Syntax

```G1ANT
selenium.open type ⟦text⟧ url ⟦text⟧ nowait ⟦bool⟧
```

## Description

This command opens a new instance of a chosen web browser and optionally navigates to a specified URL address.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`type`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes|  | Name of a web browser |
|`url`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no|  | URL address of a webpage to be loaded |
|`nowait` | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no | false | By default, waits until the webpage fully loads |
|`result` | [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | ♥result  | Name of a variable where the command's result will be stored |
| `if`           | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutselenium](G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutSeleniumVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](G1ANT.Manual/appendices/common-arguments.md) page.

## Example

This simple script opens Firefox and runs a Google search for “g1ant”:

```G1ANT
selenium.open firefox url https://www.google.co.uk/search?q=g1ant
```

