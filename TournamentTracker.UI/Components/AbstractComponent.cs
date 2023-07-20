using Microsoft.AspNetCore.Components;

namespace TournamentTracker.UI.Components
{
    public abstract class AbstractComponent : ComponentBase
    {
        public bool isVisible { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;

    }
}
