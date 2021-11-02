using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Save
{
    public class DeleteSave : MonoBehaviour
    {
        public void Delete()
        {
            string savePath = Application.persistentDataPath + "/" + Application.version + "/" + "save.xml";
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }
    }
}
