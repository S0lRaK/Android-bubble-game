using UnityEngine;
using UnityEngine.UI;

namespace Lean
{
	// This component will load localizations from a file
	// They must be in the format:
	// Phrase Name Here = Translation Here // Optional Comment Here
	[AddComponentMenu("Lean/Localization Loader")]
	public class LeanLocalizationLoader : MonoBehaviour
	{
		[LeanLanguageNameAttribute]
		public string SourceLanguage;
		
		public TextAsset Source;
		
		private static readonly char[] newlineCharacters = new char[] { '\r', '\n' };
		
		private static readonly string newlineString = "\\n";
		
		protected virtual void Start()
		{
			LoadFromSource();
		}
		
		[ContextMenu("Load From Source")]
		public void LoadFromSource()
		{
			if (Source != null && string.IsNullOrEmpty(SourceLanguage) == false)
			{
				var localization = LeanLocalization.GetInstance();
				var lines        = Source.text.Split(newlineCharacters, System.StringSplitOptions.RemoveEmptyEntries);
				
				foreach (var line in lines)
				{
					var equalsIndex = line.IndexOf('=');
					
					if (equalsIndex != -1)
					{
						var phraseName        = line.Substring(0, equalsIndex).Trim();
						var phraseTranslation = line.Substring(equalsIndex + 1).Trim();
						
						// Replace line markers with actual newlines
						phraseTranslation = phraseTranslation.Replace(newlineString, System.Environment.NewLine);
						
						// Does this entry have a comment?
						var commentIndex = phraseTranslation.IndexOf("//");
						
						if (commentIndex != -1)
						{
							phraseTranslation = phraseTranslation.Substring(0, commentIndex).Trim();
						}
						
						// Find or add the translation for this phrase
						var translation = localization.AddTranslation(SourceLanguage, phraseName);
						
						// Set the translation text for this phrase
						translation.Text = phraseTranslation;
					}
				}
				
				// Update translations?
				if (localization.CurrentLanguage == SourceLanguage)
				{
					LeanLocalization.UpdateTranslations();
				}
			}
		}
	}
}