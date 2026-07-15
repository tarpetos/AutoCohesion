using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace AutoCohesion
{
    public class AutoCohesionSettings : AttributeGlobalSettings<AutoCohesionSettings>
    {
        public override string Id => "AutoCohesionSettings";
        public override string DisplayName => new TaleWorlds.Localization.TextObject("{=auto_cohesion_settings_name}Auto Cohesion").ToString();
        public override string FolderName => "AutoCohesion";
        public override string FormatType => "json2";

        [SettingPropertyBool("{=auto_cohesion_settings_autorefill_name}Auto-refill army cohesion", Order = 1, RequireRestart = false, HintText = "{=auto_cohesion_settings_autorefill_hint}Automatically spends influence to keep the ruler's army cohesion full.")]
        [SettingPropertyGroup("{=auto_cohesion_settings_group}General")]
        public bool AutoRefillCohesion { get; set; } = true;
    }
}
