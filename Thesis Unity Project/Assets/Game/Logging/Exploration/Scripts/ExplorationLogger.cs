using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using System.Xml.Linq;
using System.Xml;

namespace DLSU.WizardCode.Logging.Exploration
{
    [CreateAssetMenu(menuName = "Logging/Exploration/ExplorationLogger")]
    public class ExplorationLogger : ScriptableObject
    {
        [SerializeField]
        private StringVariable relativePathOfLogsInDataPath;

        private XDocument explorationLogXDocument;
        private XElement explorationLogEventsRootElement;

        public void InitializeLogger()
        {
            explorationLogXDocument = new XDocument();
            XElement root = new XElement("ExplorationLog");
            explorationLogXDocument.Add(root);
            explorationLogEventsRootElement = new XElement("ExplorationLogEvents");
        }

        public void AddLog(XElement log)
        {
            XElement root = explorationLogXDocument.Root;
            if (root != null)
            {
                root.Add(log);
            }
        }

        public void AddExplorationLogEvent(XElement explorationLogEvent)
        {
            if (explorationLogEventsRootElement != null)
            {
                explorationLogEventsRootElement.Add(explorationLogEvent);
            }
        }

        public void SaveLogToDataPath(string fileName)
        {
            if (explorationLogXDocument != null)
            {
                explorationLogXDocument.Root.Add(explorationLogEventsRootElement);
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                //string savePath = Path.Combine(Application.dataPath, relativePathOfLogsInDataPath.Value);
                string savePath = Path.Combine(Application.persistentDataPath, relativePathOfLogsInDataPath.Value);
                string fileNamePath = Path.Combine(savePath, fileName);

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                using (XmlWriter xmlWriter = XmlWriter.Create(fileNamePath, xmlWriterSettings))
                {
                    explorationLogXDocument.Save(xmlWriter);
                }
            }
        }
    }
}
