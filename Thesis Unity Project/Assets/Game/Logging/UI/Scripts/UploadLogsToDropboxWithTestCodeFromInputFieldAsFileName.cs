using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Logging.UI
{
    public class UploadLogsToDropboxWithTestCodeFromInputFieldAsFileName : MonoBehaviour
    {
        [SerializeField]
        private LogsDropboxUploader logsDropboxUploader;
        [SerializeField]
        private InputField inputField;

        public void UploadLogs()
        {
            if (inputField.text.Length > 0)
            {
                string testCode = inputField.text;
                string fileName = testCode + "_LOGS.zip";
                logsDropboxUploader.StartUploadLogs(fileName);
            }
        }
    }

}
