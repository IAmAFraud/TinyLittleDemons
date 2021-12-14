using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
	public LevelList levels;

	/// <summary>
	/// Author: John Heiden
	/// Loads the given scene as the currently active scene
	/// </summary>
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	/// <summary>
	/// Author: John Heiden
	/// Updates the level list to reflect what level the player selected
	/// </summary>
	public void PrepareTangram(Text levelNum)
	{
		// SET LEVEL TO BE THE ACTIVE LEVEL IN THE LEVEL LIST
		levels.CurrentLevel = int.Parse(levelNum.text);
	}
}
