namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int min = 0;
        int max = 10;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var r = new Random();
            string res = r.Next(min, max).ToString();
            LabeMainPage.Text = res;
        }

        private void OnSettingsClicked(object sender, EventArgs e)
        {
            if (!entryMin.IsVisible)
            {
                entryMin.IsVisible = true;
                entryMax.IsVisible = true;
            }
            else
            {
                entryMin.IsVisible = false;
                entryMax.IsVisible = false;
            }
        }

        private void ChangeMinValue()
        {
           // max = int.Parse(entryMax.Text);

            string text = entryMin.Text.Replace("[a-z][A-Z][а-я][А-Я]", "");
            if (int.TryParse(text.Replace("[]{}-+=/\\|)(", ""), out int res))
            {
                min = res;
                if (min >= max)
                {
                    string newMax = string.Empty;
                    foreach (var c in min.ToString().ToCharArray())
                        newMax += "0";

                    max = int.Parse("1" + newMax);
                }
            }

            entryMin.Text = min.ToString();
            entryMax.Text = max.ToString();
        }

        private void ChangeMaxValue()
        {
            //min = int.Parse(entryMin.Text);

            string text = entryMax.Text.Replace("[a-z][A-Z][а-я][А-Я]", "");
            if (int.TryParse(text.Replace("[]{}-+=/\\|)(", ""), out int res))
            {
                max = res;
                if (min >= max)
                {
                    string newMin = string.Empty;
                    foreach (var c in min.ToString().ToCharArray())
                        newMin += "0";

                    min = int.Parse("1" + newMin.Remove(newMin.IndexOf(newMin.Last())));
                }
            }

            entryMin.Text = min.ToString();
            entryMax.Text = max.ToString();
        }

        private void OnEntryMinTextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeMinValue();
        }

        private void OnEntryMinCompleted(object sender, EventArgs e)
        {
            ChangeMinValue();
        }

        private void OnEntryMaxTextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeMaxValue();
        }

        private void OnEntryMaxCompleted(object sender, EventArgs e)
        {
            ChangeMaxValue();
        }
    }

}
