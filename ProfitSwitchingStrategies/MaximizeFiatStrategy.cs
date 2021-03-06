﻿using CryptoProfitSwitcher.Enums;
using CryptoProfitSwitcher.Models;

namespace CryptoProfitSwitcher.ProfitSwitchingStrategies
{
    public class MaximizeFiatStrategy : IProfitSwitchingStrategy
    {
        public bool IsProfitABetterThanB(Profit profitA, ProfitTimeframe timeframeA, Profit profitB, ProfitTimeframe timeframeB, double threshold)
        {
            double usdRewardA = GetReward(profitA, timeframeA);
            double usdRewardB = GetReward(profitB, timeframeB);
            return usdRewardA > usdRewardB + (usdRewardB * threshold);
        }

        private double GetReward(Profit profit, ProfitTimeframe timeframe)
        {
            double reward = 0;
            switch (timeframe)
            {
                case ProfitTimeframe.Day:
                    reward = profit.UsdRewardDay;
                    break;
                case ProfitTimeframe.Live:
                    reward = profit.UsdRewardLive;
                    break;
            }

            return reward;
        }
    }
}
