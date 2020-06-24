namespace typicalEnglish.Scripts.ViewModels
{
    public class NavigateArgs
    {
        public NavigateArgs(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}