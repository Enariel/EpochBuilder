using Epoch.Lib;
using Epoch.Lib.Models;
using EpochBuilder.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace EpochBuilder.Components
{
    public partial class WorldCreate : ComponentBase
    {
        private MudForm _form;
        private string[] _errors;
        private bool _isValid;
        private List<World> _worlds = new List<World>();
        [Inject] private ILogger<WorldCreate> Logger { get; set; }
        [Inject] private EpochDbContext Ctx { get; set; }
        [Inject] private DataService DataService { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await RefreshWorldListAsync();
        }
        private async Task RefreshWorldListAsync() => _worlds = await Ctx.Worlds.ToListAsync();

        private async Task SubmitWorld()
        {
            if (_form.IsValid)
            {
                try
                {
                    _worlds.ForEach(x => x.IsActive = false);
                    _world.CreatedOn = DateTime.Now;
                    _world.IsActive = true;
                    Ctx.Worlds.Add(_world);
                    await Ctx.SaveChangesAsync();
                    await RefreshWorldListAsync();
                    await DataService.UpdateDataAsync(Data);
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                }
                _world = new World();
                await DataService.SaveDataAsync(Data);
            }
        }
    }
}