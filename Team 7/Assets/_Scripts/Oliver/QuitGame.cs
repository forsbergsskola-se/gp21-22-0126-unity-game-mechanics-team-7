using UnityEngine;

public class QuitGame : MonoBehaviour{
    private void Awake() {
        FMODUnity.RuntimeManager.GetBus("Bus:/").setVolume(1);
    }

    public void QuitApplication(){
        Application.Quit();
    }
}
