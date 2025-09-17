using Microsoft.Extensions.Logging;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using OrchardCore.Media.Settings;
using OrchardCore.Recipes.Services;
using OrchardCore.Search.Lucene.Model;
using OrchardCore.Title.Models;

namespace Test.OrchardCore.Shape.Bindings
{
    public sealed class PermitParkDisabilMigrations : DataMigration
    {
        private readonly ILogger<PermitParkDisabilMigrations> _logger;
        private readonly IRecipeMigrator _recipeMigrator;
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public PermitParkDisabilMigrations(
          ILogger<PermitParkDisabilMigrations> logger,
        IContentDefinitionManager contentDefinitionManager,
          IRecipeMigrator recipeMigrator)
        {
            _logger = logger;
            _contentDefinitionManager = contentDefinitionManager;
            _recipeMigrator = recipeMigrator;
        }

        public async Task<int> CreateAsync()
        {
            _logger.LogInformation("creazione content type ");

            await _contentDefinitionManager.AlterTypeDefinitionAsync("PermitParkDisabil", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .DisplayedAs("PermitParkDisabil")
                .Stereotype("Pratiche")
                .WithPart("TitlePart", part => part
                    .WithPosition("0")
                    .WithSettings(new TitlePartSettings
                    {
                        Options = TitlePartOptions.GeneratedHidden,
                        Pattern = "ID - PermitParkDisabil"
                    }
                    )
                )
                .WithPart("PermitParkDisabilPart", part => part
                    .WithPosition("1")
                )
            );

            await _contentDefinitionManager.AlterPartDefinitionAsync("PermitParkDisabilPart", part => part
                .WithSettings(
                    new ContentPartSettings
                    {
                        Attachable = false,
                        DisplayName = "PermitParkDisabilPart",
                        Description = "..."
                    }
                )
                .WithField("Privacy", field => field
                    .OfType(nameof(BooleanField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "Privacy",
                    })
                    .WithSettings(new BooleanFieldSettings()
                    {
                        Label = "Privacy",
                        Hint = "Privacy"
                    })
                )
                .WithField("Att", field => field
                    .OfType(nameof(MediaField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "Att",
                        Editor = "Attached"
                    })
                    .WithSettings(new MediaFieldSettings()
                    {
                        AllowMediaText = false
                    })
                )
                .WithField("Fo", field => field
                    .OfType(nameof(MediaField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "Fo",
                        Editor = "Attached"
                    })
                    .WithSettings(new MediaFieldSettings()
                    {
                        AllowMediaText = false,
                        Hint = "..."
                    })
                )
                .WithField("TiCo", field => field
                    .OfType(nameof(TextField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "TiCo",
                        Editor = "PredefinedList"
                    })
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        Options = new[]{
                            new ListValueOption(){
                                Name = "ConPer",
                                Value = "ConPer"
                            },
                            new ListValueOption(){
                                Name = "ConTem",
                                Value = "ConTem"
                            }
                        }
                    })
                    .WithSettings(new LuceneContentIndexSettings() { Included = true, Stored = true })
                )
                .WithField("DurCon", field => field
                    .OfType(nameof(DateField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "DurCon"
                    })
                    .WithSettings(new DateFieldSettings()
                    {
                        Hint = "..."
                    })
                )
            );

            return 1;
        }
    }
}
