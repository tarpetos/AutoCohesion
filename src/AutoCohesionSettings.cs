using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;

namespace AutoCohesion
{
    public class AutoCohesionSettings : AttributeGlobalSettings<AutoCohesionSettings>
    {
        public override string Id => "AutoCohesionSettings";
        public override string DisplayName => new TaleWorlds.Localization.TextObject("{=auto_cohesion_settings_name}Auto Cohesion").ToString();
        public override string FolderName => "AutoCohesion";
        public override string FormatType => "json2";

        [SettingPropertyDropdown("{=auto_cohesion_settings_mode_name}Auto-refill mode", Order = 1, RequireRestart = false, HintText = "{=auto_cohesion_settings_mode_hint}Select when the mod should automatically refill army cohesion.")]
        [SettingPropertyGroup("{=auto_cohesion_settings_group}General")]
        public Dropdown<string> AutoRefillMode { get; set; } = new Dropdown<string>(new string[]
        {
            "{=auto_cohesion_settings_mode_always}Always refill",
            "{=auto_cohesion_settings_mode_free}Only refill if free",
            "{=auto_cohesion_settings_mode_never}Do not refill"
        }, 0);
    }
}
