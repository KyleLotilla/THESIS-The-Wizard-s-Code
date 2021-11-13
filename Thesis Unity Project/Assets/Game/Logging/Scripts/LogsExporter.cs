using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Logging
{
    public class LogsExporter : MonoBehaviour
    {
        [SerializeField]
        private StringVariable relativePathOfLogsInDataPath;
        [SerializeField]
        private UnityEventOneStringParam onLogExportedSuccessfully;
        [SerializeField]
        private UnityEventOneStringParam onLogExportFailed;
        
        public void ExportLogs(string fileName)
        {
            string sourceDirectory = Path.Combine(Application.persistentDataPath, relativePathOfLogsInDataPath.Value);
            if (Directory.Exists(sourceDirectory))
            {
#if UNITY_EDITOR
                string destDirectory = Path.Combine(Directory.GetParent(Application.dataPath).FullName, fileName);
#elif UNITY_STANDALONE_WIN
                string destDirectory = Path.Combine(Directory.GetParent(Directory.GetParent(Application.dataPath).FullName).FullName, fileName);
#else
                string destDirectory = Path.Combine(Directory.GetParent(Application.dataPath).FullName, fileName);
#endif
                if (File.Exists(destDirectory))
                {
                    File.Delete(destDirectory);
                }
                ZipFile.CreateFromDirectory(sourceDirectory, destDirectory);
                if (File.Exists(destDirectory))
                {
                    onLogExportedSuccessfully?.Invoke(destDirectory);
                }
                else
                {
                    onLogExportFailed?.Invoke("Logs unable to export to " + destDirectory);
                }
            }
            else
            {
                onLogExportFailed?.Invoke("No Logs to Export");
            }
        }
    }

}
