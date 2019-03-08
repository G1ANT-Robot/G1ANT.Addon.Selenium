# selenium.activatetab

## Syntax

```G1ANT
selenium.activatetab search ⟦text⟧ by ⟦text⟧ 
```

## Description

This command activates a browser tab specified by a part of its title or URL address.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`search`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Tab searching phrase |
|`by`| [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes|  | Tab searching constraint: `title` or `url` |
| `if`           | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](G1ANT.Manual/appendices/common-arguments.md) page.

## Example

In the following example, G1ANT website is opened in Firefox, then two tabs are added. Finally, the robot activates the first tab again using a part of its URL address as a search phrase:

```G1ANT
selenium.open firefox url g1ant.com
selenium.newtab facebook.com
selenium.newtab google.com
dialog ‴Now let's go back to the first tab‴
selenium.activatetab search g1ant by url
```
