using G1ANT.Language;

namespace G1ANT.Addon.Selenium
{
    public class SeleniumCommandArguments : CommandArguments
    {
        [Argument(Required = true, Tooltip = "Phrase to find an element by")]
        public TextStructure Search { get; set; }

        [Argument(Tooltip = "Specifies an element selector: 'id', 'class', 'cssselector', 'tag', 'xpath', 'name', 'query', 'jquery'")]
        public TextStructure By { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());

        [Argument(Tooltip = "Phrase to find an iframe by")]
        public TextStructure IFrameSearch { get; set; }

        [Argument(Tooltip = "Specifies an iframe selector: 'id', 'class', 'cssselector', 'tag', 'xpath', 'name', 'query', 'jquery'")]
        public TextStructure IFrameBy { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());
    }
}
