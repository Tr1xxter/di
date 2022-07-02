using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
    {
        private readonly IDragonPainterFactory dragonPainterFactory;
        private readonly Func<DragonSettingsGenerator> dragonSettingsGeneratorFactory;

        public DragonFractalAction(IDragonPainterFactory dragonPainterFactory, Func<DragonSettingsGenerator> dragonSettingsGeneratorFactory)
        {
            this.dragonPainterFactory = dragonPainterFactory;
            this.dragonSettingsGeneratorFactory = dragonSettingsGeneratorFactory;
        }

        public string Category => "Фракталы";
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = dragonSettingsGeneratorFactory.Invoke().Generate();
            SettingsForm.For(dragonSettings).ShowDialog();
            dragonPainterFactory.Create(dragonSettings).Paint();
        }
    }

    public interface IDragonPainterFactory
    {
        DragonPainter Create(DragonSettings settings);
    }
}