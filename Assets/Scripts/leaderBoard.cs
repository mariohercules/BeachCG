using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.UI;
using SimpleJSON;

public class MyClass
{
	public string username;
	public string score;
	public string test;
}

public class leaderBoard : MonoBehaviour {
	public static PubNub pubnub;
	public Text Line1;
	public Text Line2;
	public Text Line3;
	public Text Line4;
	public Text Line5;
	public Text Score1;
	public Text Score2;
	public Text Score3;
	public Text Score4;
	public Text Score5;

	public Button SubmitButton;
	//public InputField FieldUsername;
	//public InputField FieldScore;
	//public Object[] tiles = {}
	// Use this for initialization
	void Start () {

		//Button btn = SubmitButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);

		// Use this for initialization
		PNConfiguration pnConfiguration = new PNConfiguration ();
		pnConfiguration.PublishKey = "pub-c-552fdd0f-5c19-4557-baa4-1f8c2263b4ed";
		pnConfiguration.SubscribeKey = "sub-c-b55b4074-8312-11e9-84b9-2e401b25e788";

		pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
		pnConfiguration.UUID = Random.Range (0f, 999999f).ToString ();

		pubnub = new PubNub(pnConfiguration);
		Debug.Log (pnConfiguration.UUID);
			

		MyClass myFireObject = new MyClass();
		myFireObject.test = "Player 1";
		string fireobject = JsonUtility.ToJson(myFireObject);
		pubnub.Fire()
			.Channel("beach_cg_channel")
			.Message(fireobject)
			.Async((result, status) => {
				if(status.Error){
					Debug.Log (status.Error);
					Debug.Log (status.ErrorData.Info);
				} else {
					Debug.Log (string.Format("Fire Timetoken: {0}", result.Timetoken));
				}
			});
		
		pubnub.SusbcribeCallback += (sender, e) => { 
			SusbcribeEventEventArgs mea = e as SusbcribeEventEventArgs;
			if (mea.Status != null) {
			}
			if (mea.MessageResult != null) {
				Dictionary<string, object> msg = mea.MessageResult.Payload as Dictionary<string, object>;

				string[] strArr = msg["username"] as string[];
				string[] strScores = msg["score"] as string[];

				int usernamevar = 1;
				foreach (string username in strArr)
				{
					string usernameobject = "Line" + usernamevar;
					GameObject.Find(usernameobject).GetComponent<Text>().text = usernamevar.ToString() + ". " + username.ToString();
					usernamevar++;
					Debug.Log(username);
				}

				int scorevar = 1;
				foreach (string score in strScores)
				{
					string scoreobject = "Score" + scorevar;
					GameObject.Find(scoreobject).GetComponent<Text>().text = "Score: " + score.ToString();
					scorevar++;
					Debug.Log(score);
				}
			}
			if (mea.PresenceEventResult != null) {
				Debug.Log("In Example, SusbcribeCallback in presence" + mea.PresenceEventResult.Channel + mea.PresenceEventResult.Occupancy + mea.PresenceEventResult.Event);
			}
		};
		pubnub.Subscribe ()
			.Channels (new List<string> () {
                "beach_cg_channel"
            })
			.WithPresence()
			.Execute();
	}

	public void TaskOnClick()
	{
		//var usernametext = FieldUsername.text;
		//var scoretext = FieldScore.text;

		MyClass myObject = new MyClass();
        myObject.username = Variables.player_name;
		myObject.score = Variables.points.ToString();
		string json = JsonUtility.ToJson(myObject);

		pubnub.Publish()
			.Channel("beach_cg_channel")
			.Message(json)
			.Async((result, status) => {    
				if (!status.Error) {
					Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
				} else {
					Debug.Log(status.Error);
					Debug.Log(status.ErrorData.Info);
				}
			});
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
	}

}
