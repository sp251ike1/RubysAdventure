using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class take care of updating the dialogue text, hiding/showing the dialogue box and changing the portrait.
/// It is a singleton so the text/portrait can be changed from anywhere.
/// </summary>
public class UIDialogueBox : MonoBehaviour
{
	public static UIDialogueBox Instance { get; private set; }
	
	public Image portrait;
	public TextMeshProUGUI text;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		//disable on start, will be shown/hidden by the dialogue triggers.
		gameObject.SetActive(false);	
	}


	public void DisplayText(string content)
	{
		text.text = content;
	}

	public void DisplayPortrait(Sprite spr)
	{
		portrait.sprite = spr;
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}
	
	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public Text fixedRobotsText;
    public Text winMessageText;
    public Text loseMessageText;
	
    private int fixedRobotsCount = 0;

    // Call this method when a robot is fixed
    public void IncrementFixedRobotsCount()
    {
        fixedRobotsCount++;
        UpdateFixedRobotsUI();
        CheckWinCondition();
    }

    // Update the "Fixed Robots" UI Text
    void UpdateFixedRobotsUI()
    {
        fixedRobotsText.text = "Fixed Robots: " + fixedRobotsCount;
    }

    // Check if all robots are fixed, show win message if true
    void CheckWinCondition()
    {
        if (fixedRobotsCount == totalRobotCount)  // Replace totalRobotCount with the actual total number of robots
        {
            winMessageText.text = "You Win! Game Created by Team Coding 18 Press R to restart";
        }
    }

	// Call this method when the player loses
    public void PlayerLose()
    {
        loseMessageText.text = "You lost! Press R to restart";
    }
}
