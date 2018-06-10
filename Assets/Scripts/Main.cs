using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {Play, Clear, Over}

public class Main : MonoBehaviour {

    public static GameState gameState;

    public GameObject player;
    public GameObject gameOverArea;
    public GameObject itemPrefab;
    public GameObject rulePanel;
    public bool isOpenRule = false;
    public Text pointText;
    public GameObject resultPanel;
    public Text countText, messageText;
    string resultMessage;

    public static int itemCount = 0;

	// Use this for initialization
	void Start () {
        gameState = GameState.Play;
        itemCount = 0;
        for(int i = 0; i < 100; i++) {
            Vector3 v = new Vector3(Random.Range(-50.0f, 50.0f), 1.0f, Random.Range(-50.0f, 50.0f));
            GameObject items = Instantiate(itemPrefab);
            items.transform.position = v;
        }
        resultPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(gameState == GameState.Play) {
            pointText.text = "ジョッキ：" + itemCount + "杯";
        }

		if(gameState == GameState.Over) {

            resultPanel.SetActive(true);
            countText.text = "ジョッキ：" + itemCount + "杯";

            if(itemCount < 10) {
                resultMessage = "「ありえないですよね。普通に」";
            }
            else if(itemCount < 30){
                resultMessage = "「『申し訳ございません』と言うのが筋じゃないかって」";
            }
            else if(itemCount < 50) {
                resultMessage = "「何でしょうね、裏切りですよね」";
            }
            else if(itemCount < 70) {
                resultMessage = "「筋を通す男だと思っていたんですけどね」";
            }
            else if(itemCount < 90) {
                resultMessage = "「そんな甘えた言葉は聞きたくなかったです」";
            }
            else {
                resultMessage = "「正直あなたは病気です」";
            }

            messageText.text = resultMessage;
        }
	}

    public void OnClickHighScoreButton() {
        // Type == Number の場合
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(itemCount);
    }

    public void OnClickRule() {
        rulePanel.SetActive(!isOpenRule);
        isOpenRule = !isOpenRule;
        Time.timeScale = isOpenRule ? 0.0f : 1.0f;
    }

    public void OnClickRestart() {
        SceneManager.LoadScene("Main");
    }

    public void OnClickTweetButton() {
        string shareText = "↓クソゲープレイ結果↓" + "\nジョッキを" + itemCount + "杯飲んだ！" + "\n評価：" + resultMessage;
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(shareText + "\n\n" + "#席がそこにあるのならば"));
    }
}
