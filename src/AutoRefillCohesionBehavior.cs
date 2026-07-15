using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace AutoCohesion
{
    public class AutoRefillCohesionBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.HourlyTickEvent.AddNonSerializedListener(this, new System.Action(this.OnHourlyTick));
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        private void OnHourlyTick()
        {
            try
            {
                if (!IsAutoRefillEnabled())
                {
                    return;
                }

                Clan playerClan = Clan.PlayerClan;
                if (playerClan == null || playerClan.Kingdom == null)
                {
                    return;
                }

                MobileParty leaderParty = playerClan.Leader?.PartyBelongedTo;
                if (leaderParty == null)
                {
                    return;
                }

                Army army = leaderParty.Army;
                if (army != null && army.LeaderParty == leaderParty)
                {
                    if (army.Cohesion <= 90f)
                    {
                        int amountToBoost = 10;
                        int cost = Campaign.Current.Models.ArmyManagementCalculationModel.GetCohesionBoostInfluenceCost(army, amountToBoost);
                        
                        if (playerClan.Influence >= cost)
                        {
                            army.BoostCohesionWithInfluence(amountToBoost, cost);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private bool IsAutoRefillEnabled()
        {
            try
            {
                if (AutoCohesionSettings.Instance != null)
                {
                    return AutoCohesionSettings.Instance.AutoRefillCohesion;
                }
            }
            catch
            {
            }
            return false;
        }
    }
}
