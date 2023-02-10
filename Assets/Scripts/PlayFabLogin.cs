using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private string _playFabTitle;
    [SerializeField] private Button _playFabloginButton;
    [SerializeField] private Text _errorLabel;

    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = _playFabTitle;
        }

        _playFabloginButton.onClick.AddListener(LoginButtonPressed);
    }

    private void LoginButtonPressed()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "Player_1",
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        _playFabloginButton.interactable = false;
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made successful API call!");
        _errorLabel.text = "Login granted";
        _errorLabel.color = Color.green;
    }

    private void OnLoginFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.LogError($"Something went wrong: {errorMessage}");
        _errorLabel.text = "Invalid user name or password";
        _errorLabel.color = Color.red;
    }
}