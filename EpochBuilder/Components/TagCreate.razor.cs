using Epoch.Lib;
using Epoch.Lib.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System.Data.Common;

namespace EpochBuilder.Components
{
    public partial class TagCreate
    {
        [Inject] private ILogger<TagCreate> Logger { get; set; }
        [Inject] private EpochDbContext Ctx { get; set; }
        private Tag _tag = new Tag();
        private MudForm _form;
        private bool _isValid;
        private async void SubmitTag(MouseEventArgs obj)
        {
            if (!_form.IsValid)
                return;

            _tag.CreatedOn = DateTime.Now;
            await Ctx.Tags.AddAsync(_tag);
            try
            {
                await Ctx.SaveChangesAsync();
            }
            catch (DbException e)
            {
                Logger.LogError(e.Message);
            }
            _tag = new Tag();
        }
    }
}