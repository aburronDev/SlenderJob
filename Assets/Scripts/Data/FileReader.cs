using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace aburron.Data
{
	public class FileReader : MonoBehaviour
	{
		[SerializeField, Editor.Required] TextMeshProUGUI dataText;
		[SerializeField] private string folderPath;
		[SerializeField] private string fileNamePattern;
		[SerializeField] private string fileExtension;

		public void WriteDataText(int fileIndex)
		{
			var filePath =
				$"{Application.streamingAssetsPath}/{folderPath}/{fileNamePattern}{fileIndex}.{fileExtension}";
			var fileText = System.IO.File.ReadAllText(filePath);

			dataText.text = fileText;
		}
	}
}