using Microsoft.Extensions.Logging;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using OrchardCore.Media.Settings;
using OrchardCore.Recipes.Services;
using OrchardCore.Search.Lucene.Model;
using OrchardCore.Title.Models;

namespace Test.OrchardCore.Shape.Bindings
{
    public sealed class AccessToActEdilMigrations : DataMigration
    {
        private readonly ILogger<AccessToActEdilMigrations> _logger;
        private readonly IRecipeMigrator _recipeMigrator;
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public AccessToActEdilMigrations(
          ILogger<AccessToActEdilMigrations> logger,
        IContentDefinitionManager contentDefinitionManager,
          IRecipeMigrator recipeMigrator)
        {
            _logger = logger;
            _contentDefinitionManager = contentDefinitionManager;
            _recipeMigrator = recipeMigrator;
        }

        public async Task<int> CreateAsync()
        {
            _logger.LogInformation("creazione content type");

            await _contentDefinitionManager.AlterTypeDefinitionAsync("AccessToActEdil", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .DisplayedAs("AccessToActEdil")
                .Stereotype("Pratiche")
                .WithPart("TitlePart", part => part
                    .WithPosition("0")
                    .WithSettings(new TitlePartSettings
                    {
                        Options = TitlePartOptions.GeneratedHidden,
                        Pattern = "ID - AccessToActEdil"
                    }
                    )
                )
                .WithPart("AccessToActEdilPart", part => part
                    .WithPosition("4")
                )
            );

            await _contentDefinitionManager.AlterPartDefinitionAsync("AccessToActEdilPart", part => part
                .WithSettings(
                    new ContentPartSettings
                    {
                        Attachable = false,
                        DisplayName = "AccessToActEdilPart",
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
                .WithField("Mot", field => field
                    .OfType(nameof(TextField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "Mot"
                    })
                    .WithSettings(new TextFieldSettings()
                    {
                        Hint = "..."
                    })
                )
                .WithField("MotAtt", field => field
                    .OfType(nameof(MediaField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "MotAtt",
                        Editor = "Attached"
                    })
                    .WithSettings(new MediaFieldSettings()
                    {
                        AllowMediaText = false,
                        Hint = "..."
                    })
                )
                .WithField("Sbj", field => field
                    .OfType(nameof(TextField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "Sbj?",
                        Editor = "PredefinedList"
                    })
                    .WithSettings(new TextFieldSettings() {
                        Required = true,
                        Hint = "..."
                    })
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        Options = new[]{
                            new ListValueOption(){
                                Name = "Me",
                                Value = "Me"
                            },
                            new ListValueOption(){
                                Name = "Oth",
                                Value = "Oth"
                            }
                        }
                    })
                )
                .WithField("SbjA", field => field
                    .OfType(nameof(MediaField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "SbjA",
                        Editor = "Attached"
                    })
                    .WithSettings(new MediaFieldSettings()
                    {
                        AllowMediaText = false,
                        Hint = "..."
                    })
                )
                .WithField("ModA", field => field
                    .OfType(nameof(TextField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "ModA",
                        Editor = "PredefinedList"
                    })
                    .WithSettings(new TextFieldSettings
                    {
                        Required = true,
                        Hint = "..."
                    })
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        Options = new[]{
                            new ListValueOption(){
                                Name = "Vis",
                                Value = "Vis"
                            },
                            new ListValueOption(){
                                Name = "Copy",
                                Value = "Copy"
                            },
                            new ListValueOption(){
                                Name = "Phy",
                                Value = "Phy"
                            }
                        }
                    })
                )
                .WithField("ModD", field => field
                    .OfType(nameof(TextField))
                    .WithSettings(new ContentPartFieldSettings
                    {
                        DisplayName = "ModD",
                        Editor = "TextArea"
                    })
                    .WithSettings(new TextFieldSettings()
                    {
                        Required = true,
                        Hint = "..."
                    })
                )
            );

            return 1;
        }
    }
}
