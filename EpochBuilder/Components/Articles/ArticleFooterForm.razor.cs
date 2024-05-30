using Epoch.Lib.Models;
using Microsoft.AspNetCore.Components;

namespace EpochBuilder.Components
{
    public partial class ArticleFooterForm : ComponentBase
    {
        [Parameter] public ArticleFooter Footer { get; set; } = new ArticleFooter();

        private bool _isValid;
    }
}