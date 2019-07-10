# selenium.runscript

## Syntax

```G1ANT
selenium.runscript script ⟦text⟧ waitfornewwindow ⟦bool⟧
```

## Description

This command runs Javascript code inside the web browser.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`script` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Script to be executed in the web browser |
|`waitfornewwindow` | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no | false | If set to `true`, the command should wait for a new window to appear after the script execution |
| `result`       | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       | `♥result`                                                   | Name of a variable where the command's result will be stored |
| `if`           | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutselenium](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutSeleniumVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

> **Note:** the `selenium.` commands require opening a browser with the `selenium.open` command first, and they refer to the browser’s first tab by default. If you have more tabs opened and want to use the `selenium.` commands on a tab other than the first one, use the `selenium.activatetab` command to change the active tab.

## Example

In the following script the robot opens Google site and uses Javascript to return the `.tagName` of some component on the webpage — `body`, in this case. To select this `body` element a Javascript structure is used: `document.querySelector("body")`. It is a standard Javascript syntax for choosing elements on a webpage:

```G1ANT
selenium.open chrome url google.com
selenium.runscript ‴return document.querySelector("body").tagName‴
dialog ♥result
```

> **Note:** It is crucial to use `return` keyword before Javascript code if this code is designed to return something.
