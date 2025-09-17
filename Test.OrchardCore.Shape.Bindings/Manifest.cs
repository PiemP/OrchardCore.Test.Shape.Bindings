using OrchardCore.Modules.Manifest;
using Test.OrchardCore.Shape.Bindings;

[assembly: Module(
    Id = "Test.OrchardCore.Shape.Bindings",
    Name = "...",
    Author = "XSX",
    Website = "XSX",
    Version = "XSX",
    Description = "...",
    Category = "Content"
)]

// [assembly: Feature(
//     Id = PermessiConst.Main,
//     EnabledByDependencyOnly = true,
//     Name = "...",
//     Description = "...",
//     Category = "Content",
//     Dependencies = new[] {
//         PermessiConst.PermitParkDisabil,
//         PermessiConst.AccessToAct,
//         PermessiConst.AccessToActEdil,
//         PermessiConst.AccessCivic
//         }
// )]

[assembly: Feature(
    Id = PermessiConst.PermitParkDisabil,
    Name = "...",
    Description = "...",
    Category = "Content"
)]

[assembly: Feature(
    Id = PermessiConst.AccessToAct,
    Name = "...",
    Description = "...",
    Category = "Content"
)]

[assembly: Feature(
    Id = PermessiConst.AccessToActEdil,
    Name = "...",
    Description = "...",
    Category = "Content"
)]

[assembly: Feature(
    Id = PermessiConst.AccessCivic,
    Name = "...",
    Description = "...",
    Category = "Content"
)]

