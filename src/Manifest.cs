using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "OrchardCore Module Resume",
    Author = "Pierre-Henri Nogues",
    Website = "https://www.pierrehenri.fr",
    Version = "0.0.1",
    Description = "Orchard Core module to display your resume",
    Category = "Content Management",
    Dependencies =
    [
        "OrchardCore.ContentFields",
        "OrchardCore.Contents",
        "OrchardCore.ContentTypes",
        "OrchardCore.Features",
        "OrchardCore.Layers",
        "OrchardCore.Localization",
        "OrchardCore.Media",
        "OrchardCore.Recipes",
        "OrchardCore.Settings",
    ]
)]