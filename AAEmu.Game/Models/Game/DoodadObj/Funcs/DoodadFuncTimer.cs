﻿using System;

using AAEmu.Game.Core.Managers;
using AAEmu.Game.Models.Game.DoodadObj.Templates;
using AAEmu.Game.Models.Game.Units;
using AAEmu.Game.Models.Tasks.Doodads;

namespace AAEmu.Game.Models.Game.DoodadObj.Funcs
{
    public class DoodadFuncTimer : DoodadFuncTemplate
    {
        public int Delay { get; set; }
        public int NextPhase { get; set; }
        public bool KeepRequester { get; set; }
        public bool ShowTip { get; set; }
        public bool ShowEndTime { get; set; }
        public string Tip { get; set; }

        public override void Use(Unit caster, Doodad owner, uint skillId, int nextPhase = 0)
        {
            //_log.Trace("Delay " + Delay);
            //_log.Trace("NextPhase " + NextPhase);
            //_log.Trace("KeepRequester " + KeepRequester);
            //_log.Trace("ShowTip " + ShowTip);
            //_log.Trace("ShowEndTime " + ShowEndTime);
            //_log.Trace("Tip " + Tip);

            owner.GrowthTime = DateTime.UtcNow.AddMilliseconds(Delay + 1); // TODO need here

            if (NextPhase > 0)
            {
                owner.FuncTask = new DoodadFuncTimerTask(caster, owner, skillId, NextPhase);
                TaskManager.Instance.Schedule(owner.FuncTask, TimeSpan.FromMilliseconds(Delay + 1));
            }
            else
            {
                //Wondering if more needs done here if depending on next phase func
                owner.Use(caster, skillId);
            }
            owner.ToPhaseAndUse = false;
        }
    }
}
