﻿using Windows.ApplicationModel.Background;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace ChamaeleoIoT.Service
{
    public sealed class StartupTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task from closing prematurely
            // by using BackgroundTaskDeferral as described in http://aka.ms/backgroundtaskdeferral
        }
    }
}
