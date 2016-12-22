using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsPanel : MonoBehaviour {

    public Button BackButton;
    public MultiplayerManager NetManager;


    public void OnBackButtonClick() {
        NetManager.SwitchPanel(NetManager.MainMenuPanel);
    }
}
