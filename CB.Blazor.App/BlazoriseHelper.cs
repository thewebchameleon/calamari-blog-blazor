using Blazorise;

namespace CB.Blazor.App
{
    public class BlazoriseHelper
    {
        public static Color ResolveColour(string colour)
        {
            if (colour == "Primary")
            {
                return Color.Primary;
            }
            if (colour == "Secondary")
            {
                return Color.Secondary;
            }
            if (colour == "Success")
            {
                return Color.Success;
            }
            if (colour == "Info")
            {
                return Color.Info;
            }
            if (colour == "Warning")
            {
                return Color.Warning;
            }
            if (colour == "Danger")
            {
                return Color.Danger;
            }
            if (colour == "Light")
            {
                return Color.Light;
            }
            if (colour == "Dark")
            {
                return Color.Dark;
            }

            //todo: do something
            return Color.Dark;
        }
    }
}
