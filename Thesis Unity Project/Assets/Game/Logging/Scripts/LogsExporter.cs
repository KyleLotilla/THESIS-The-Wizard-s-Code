using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Logging
{
    public class LogsExporter : MonoBehaviour
    {
        [SerializeField]
        private StringVariable relativePathOfLogsInDataPath;
        
        public void ExportLogs(string fileName)
        {
            string sourceDirectory = Path.Combine(Application.dataPath, relativePathOfLogsInDataPath.Value);
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
            }
        }
    }

}
