# selenium.waitforvalue

## Syntax

```G1ANT
selenium.waitforvalue script ⟦text⟧ expectedvalue ⟦text⟧
```

## Description

This command waits for a Javascript code to return a specified value.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`script`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | The full Javascript code to be evaluated in the browser |
|`expectedvalue`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Expected value that will be returned by the script |
| `if`           | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](G1ANT.Manual/appendices/common-arguments.md) page.

## Example

With the `selenium.waitforvalue` command you can check if an element on the webpage is fully loaded, so that the robot can perform further actions. It is useful when you want to make sure that a certain element is ready for typing inside of it.

In the script below Google is opened in Chrome, then the robot waits for the result of a Javascript code. This code searches for all elements named “q” and if there is at least one, the robot types “*fluffy robots*” phrase in the search field:

```G1ANT
selenium.open chrome url google.com
selenium.waitforvalue ‴return document.querySelectorAll('input[name=q]').length > 0‴ expectedvalue true timeout 20000
selenium.type ‴fluffy robots‴ search input[name=q] by cssselector
selenium.close
```

