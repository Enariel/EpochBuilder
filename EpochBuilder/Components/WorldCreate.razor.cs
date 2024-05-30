using Epoch.Lib.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace EpochBuilder.Components
{
    public partial class WorldCreate : ComponentBase
    {
        private MudForm _form;
        private string[] _errors;
        private bool _isValid;

        private void SubmitWorld()
        {
            if (_form.IsValid)
            {
                Data.Worlds.Add(_world);
                _world = new World();
            }
        }
    }
}