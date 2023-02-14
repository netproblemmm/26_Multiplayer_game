using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class SignInWindow : AccountDataWindowBase
{
    [SerializeField] private Button _signInButton;
    [SerializeField] private Canvas _loadingProgress;

    protected override void SubscriptionElementsUi()
    {
        base.SubscriptionElementsUi();
        _signInButton.onClick.AddListener(SignIn);
    }

    private void SignIn()
    {
        _loadingProgress.enabled = true;
        
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _password
        }, result =>
        {
            Debug.Log($"Success: {_username}");
            EnterInGameScene();
        }, error =>
        {
            Debug.LogError($"Fail: {error.ErrorMessage}");
        });
    }
}
