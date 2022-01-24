using G1ANT.Language;

namespace G1ANT.Addon.Selenium
{
    public class SeleniumIFrameArguments : CommandArguments
    {
        [Argument(Tooltip = "Phrase to find an iframe by")]
        public Structure IFrameSearch { get; set; }

        [Argument(Tooltip = "Specifies an iframe selector: 'id', 'class', 'cssselector', 'tag', 'xpath', 'name', 'query', 'jquery'")]
        public Structure IFrameBy { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());
    }
}
