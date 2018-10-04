using G1ANT.Language;

namespace G1ANT.Addon.Selenium
{
    public class SeleniumCommandArguments : CommandArguments
    {
        [Argument(Required = true, Tooltip = "Phrase to find element by")]
        public TextStructure Search { get; set; }

        [Argument(Tooltip = "Specifies an element selector, possible values are: 'name', 'title', 'class', 'id', 'selector', 'query', 'jquery'")]
        public TextStructure By { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());

        [Argument(Tooltip = "Phrase to find iframe by")]
        public TextStructure IFrameSearch { get; set; }

        [Argument(Tooltip = "Specifies an element selector for iframe search, possible values are: 'name', 'title', 'class', 'id', 'selector', 'query', 'jquery'")]
        public TextStructure IFrameBy { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());
    }
}
