using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{

    void Start() {
        StartCoroutine(LoginRoutine());
    }

    private IEnumerator LoginRoutine() {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) => {
            if (response.success)
            {
                print("Player logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            } else
            {
                Debug.Log("Error");
                done = true;
            }
        });

        yield return new WaitUntil(() => done);
    }

}
