using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Logging.TitleScreen
{
    public class ExportLogsWithTestCodeFromInputFieldAsFileName : MonoBehaviour
    {
        [SerializeField]
        private LogsExporter logsExporter;
        [SerializeField]
        private InputField inputField;

        public void ExportLogs()
        {
            if (inputField.text.Length > 0)
            {
                string testCode = inputField.text;
                string fileName = testCode + "_LOGS.zip";
                logsExporter.ExportLogs(fileName);
            }
        }
    }

}
