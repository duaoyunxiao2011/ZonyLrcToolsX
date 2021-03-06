﻿using Zony.Lib.Infrastructures.Common.Interfaces;
using Zony.Lib.Infrastructures.Dependency;
using Zony.Lib.Infrastructures.EventBus;
using Zony.Lib.Infrastructures.EventBus.Handlers;
using Zony.Lib.Plugin.Common;

namespace ZonyLrcTools.Events
{
    public class ProgramExitEventData : EventData
    {

    }

    public class ProgramExitEvent : IEventHandler<ProgramExitEventData>,ITransientDependency
    {
        private readonly IConfigurationManager _configMgr;

        public ProgramExitEvent(IConfigurationManager configMgr)
        {
            _configMgr = configMgr;
        }

        public void HandleEvent(ProgramExitEventData eventData)
        {
            _configMgr.SaveConfiguration();
            GlobalContext.Instance.LyricDownloadState = false;
        }
    }
}
