using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;
using System.Collections;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace DLSU.WizardCode.Logging
{
    public class LogsDropboxUploader : MonoBehaviour
    {
        [SerializeField]
        private StringVariable dropboxUploadURL;
        [SerializeField]
        private StringVariable dropboxAccessToken;
        [SerializeField]
        private StringVariable relativePathOfLogsInDataPath;
        [SerializeField]
        private UnityEvent onUploadStart;
        [SerializeField]
        private UnityEventOneFloatParam onUploadProgressed;
        [SerializeField]
        private UnityEvent onUploadSuccessfully;
        [SerializeField]
        private UnityEventOneStringParam onUploadFailed;

        public void StartUploadLogs(string fileName)
        {
            StartCoroutine(UploadLogs(fileName));
        }

        private IEnumerator UploadLogs(string fileName)
        {
            string sourceDirectory = Path.Combine(Application.persistentDataPath, relativePathOfLogsInDataPath.Value);
            if (Directory.Exists(sourceDirectory))
            {
                string destDirectory = Path.Combine(Application.persistentDataPath, fileName);
                if (File.Exists(destDirectory))
                {
                    File.Delete(destDirectory);
                }
                ZipFile.CreateFromDirectory(sourceDirectory, destDirectory);
                if (File.Exists(destDirectory))
                {
                    byte[] logsZipFile = File.ReadAllBytes(destDirectory);
                    /*
                    List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
                    formData.Add(new MultipartFormFileSection(fileName, logsZipFile));
                    */
                    UnityWebRequest postRequest = new UnityWebRequest(dropboxUploadURL.Value, UnityWebRequest.kHttpVerbPOST);
                    postRequest.downloadHandler = new DownloadHandlerBuffer();
                    postRequest.uploadHandler = new UploadHandlerRaw(logsZipFile);
                    postRequest.SetRequestHeader("Authorization", "Bearer " + dropboxAccessToken.Value);
                    postRequest.SetRequestHeader("Content-Type", "application/octet-stream");
                    postRequest.SetRequestHeader("Dropbox-API-Arg", "{\"path\": \"/Logs/" + fileName + "\",\"mode\": \"add\",\"autorename\": true,\"mute\": true,\"strict_conflict\": false}");
                    onUploadStart?.Invoke();
                    postRequest.SendWebRequest();

                    while (!postRequest.isDone)
                    {
                        yield return null;
                        onUploadProgressed?.Invoke(postRequest.uploadProgress);
                    }

                    if (postRequest.isHttpError || postRequest.isNetworkError)
                    {
                        onUploadFailed?.Invoke(postRequest.downloadHandler.text);
                    }
                    else
                    {
                        onUploadSuccessfully?.Invoke();
                    }
                }
                else
                {
                    onUploadFailed?.Invoke("Logs unable to zip in " + destDirectory);
                }
            }
            else
            {
                onUploadFailed?.Invoke("No Logs to Upload");
            }
        }
    }
}
