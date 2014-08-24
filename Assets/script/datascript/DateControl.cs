using UnityEngine;
using System.Collections;

public class DateControl : MonoBehaviour {

    public static string Name;
    public static int Num;
    bool JBstart;
    float fullWidth;
    float fullHeight;
    Rect fullScreen;
    //窗口
    Rect NameText;
    Rect GoBtn;
    Rect pointOut;
    bool JBlb;//用来显示提示文字
	// Use this for initialization
    //静态方法
    public static int getNum()
    {
        return PlayerPrefs.GetInt("_Num");
    }
    public static string getName()
    {
        return PlayerPrefs.GetString("_NAME");
    }
	void Start () {
        JBlb = true;
        fullHeight = Screen.height;
        fullWidth = Screen.width;
        JBstart = false;
        NameText = new Rect((fullWidth / 10) * 3, (fullHeight / 10) * 4, (fullWidth / 10) * 4, (fullHeight / 10) * 2);
        GoBtn = new Rect((fullWidth / 10) * 3, (fullHeight / 10) * 6, (fullWidth / 10) * 4, (fullHeight / 10) * 2);
        fullScreen = new Rect(0, 0, Screen.width, Screen.height);
        pointOut = new Rect((fullWidth / 10) * 3, (fullHeight / 10) * 3, (fullWidth / 10) * 4, (fullHeight / 10) * 1);
        if (PlayerPrefs.HasKey("_NAME"))//根据是否有姓名来判断
        {
            //载入数据
            Name = PlayerPrefs.GetString("_NAME");
            Num = PlayerPrefs.GetInt("_Num");
            this.gameObject.AddComponent("Startmenu");
            //
        }
        else
        {
            //初始化数据
            Name = "";
            Num=0;
            JBstart = true;
            PlayerPrefs.SetString("_NAME", Name);
            PlayerPrefs.SetInt("_Num", Num);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
    void WinStart(int WinID)
    {
        if (JBlb)
        {
            GUI.Label(pointOut, "请输入你的名字");
        }
        else
        {
            GUI.Label(pointOut, "名字不合规范");
        }
        Name = GUI.TextField(NameText, Name,20);
        if(GUI.Button(GoBtn,"确认"))
        {
            if (!(Name.Equals("")))
            {
                PlayerPrefs.SetString("_NAME", Name);
                JBstart = false;
                this.gameObject.AddComponent("Startmenu");
            }
            else
            {
                JBlb = false;
            }
        }
    }
    void OnGUI()
    {
        if (JBstart)
        {
            GUI.Window(0, fullScreen, WinStart, "出行");
        }
    }
}
