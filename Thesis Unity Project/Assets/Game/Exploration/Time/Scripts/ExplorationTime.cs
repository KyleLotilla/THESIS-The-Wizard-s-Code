using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Exploration.Time
{
    [CreateAssetMenu(menuName ="Exploration/ExplorationTime")]
    public class ExplorationTime : ScriptableObject
    {
        private DateTime explorationTimeStart = DateTime.MinValue;
        public DateTime ExplorationTimeStart
        {
            get
            {
                return explorationTimeStart;
            }
        }

        private DateTime explorationTimeEnd = DateTime.MinValue;
        public DateTime ExplorationTimeEnd
        {
            get
            {
                return explorationTimeEnd;
            }
        }

        public TimeSpan ExplorationDuration
        {
            get
            {
                TimeSpan explorationDuration = new TimeSpan();
                if (explorationTimeStart != DateTime.MinValue && explorationTimeEnd != DateTime.MinValue)
                {
                    explorationDuration = explorationTimeEnd - explorationTimeStart;
                }
                return explorationDuration;
            }
        }

        public TimeSpan TimeStamp
        {
            get
            {
                TimeSpan timeStamp = new TimeSpan();
                if (explorationTimeStart != DateTime.MinValue)
                {
                    timeStamp = DateTime.Now - explorationTimeStart;
                }
                return timeStamp;
            }
        }

        public string FormattedTimeStampString
        {
            get
            {
                TimeSpan timeStamp = TimeStamp;
                string formattedTimeStampString = timeStamp.Hours.ToString("D2") + ":" + timeStamp.Minutes.ToString("D2") + ":" + timeStamp.Seconds.ToString("D2");
                return formattedTimeStampString;
            }
        }

        public void StartExplorationTime()
        {
            explorationTimeStart = DateTime.Now;
        }

        public void EndExplorationTime()
        {
            explorationTimeEnd = DateTime.Now;
        }
    }

}
