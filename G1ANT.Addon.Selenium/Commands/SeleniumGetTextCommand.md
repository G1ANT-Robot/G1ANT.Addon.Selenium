# selenium.gettext

## Syntax

```G1ANT
selenium.gettext search ⟦text⟧ by ⟦text⟧ iframesearch ⟦text⟧ iframeby ⟦text⟧
```

## Description

This command gets text (a value) of a specified element.

| Argument       | Type                                                         | Required | Default Value                                                | Description                                                  |
| -------------- | ------------------------------------------------------------ | -------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| `search`       | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes      |                                                              | Phrase to find an element by                                 |
| `by`           | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                              | Specifies an element selector: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery` |
| `iframesearch` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                              | Phrase to find an iframe by                                  |
| `iframeby`     | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                              | Specifies an iframe selector: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery` |
| `result`       | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       | `♥result`                                                    | Name of a variable where the value of a specified attribute will be stored |
| `if`           | [bool](G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                         | Executes the command only if a specified condition is true   |
| `timeout`      | [timespan](G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutselenium](G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutSeleniumVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`    | [procedure](G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                              | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`    | [label](G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                              | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                              | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                              | Name of a variable that will store the returned exception. The variable will be of [error](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](G1ANT.Manual/appendices/common-arguments.md) page.

## Example

In this example the robot opens Google Finance in Chrome, then searches for an element specified by its XPath and returns the value of this element. Here, the current USD/EUR quote will be displayed in a dialog box:

```G1ANT
selenium.open chrome url https://www.google.com/finance
selenium.gettext search //*[@id="kp-wp-tab-MARKET_SUMMARY"]/div[2]/div/div[3]/div[2]/div/div/div/div[1]/g-link/a/div/div[1]/span/span by xpath result ♥quote
dialog ‴USD/EUR quote: ‴♥quote
selenium.close
```

> **Note:** The element could also be searched by other selectors: `id`, `class`, `cssselector`, `tag`, `xpath`, `name`, `query`, `jquery`. In order to search any element on a website using the `selenium.gettext` command, you need to use web browser developer tools (right-click an element and select `Inspect element` or `Inspect` from the resulting context menu).

