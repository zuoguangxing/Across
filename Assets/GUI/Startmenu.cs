using UnityEngine;
using System.Collections;

public class Startmenu : MonoBehaviour
{
    
    float fullWidth;
    float fullHeight;
    Rect rtFullscreen;
    Rect rtBeginBtn;
    //窗口定义
    //这个玩意的效果就是只让一个窗口存在
    bool WindowsExist;
    //关于窗口
    Rect rtInfoBtn;
    Rect rtInfoWin;
    bool stInfoWin;
    Rect rtInfoWinBtn;
    //设置窗口
    Rect rtSetupBtn;
    Rect rtSetupWin;
    bool stSetupWin;
    Rect rtSetupWinBtn;
    //关卡窗口
    Rect rtLevelBtn;
    Rect rtLevelWin;
    bool stLevelWin;
    Rect rtLevelWinBtn;
    //仍然是关卡窗口
    bool[] LevelBtnNum;

	// Use this for initialization
	void Start () {
        WindowsExist = false;
        fullWidth=Screen.width;
        fullHeight=Screen.height;
        rtFullscreen = new Rect(0, 0, fullWidth, fullHeight);
        rtBeginBtn = new Rect(fullWidth/2, (float)(fullHeight*0.382), (float)(fullWidth * 0.309), (float)(fullHeight * 0.2));
        rtLevelBtn = new Rect(fullWidth / 2, (float)(fullHeight * 0.25), (float)(fullWidth * 0.2), (float)(fullHeight * 0.132));
        rtSetupBtn = new Rect(fullWidth/2,(float)(fullHeight*0.582),(float)(fullWidth*0.2),(float)(fullHeight*0.118));
        rtInfoBtn = new Rect (fullWidth/2,(float)(fullHeight*0.7),(float)(fullWidth*0.15),(float)(fullHeight*0.1));
        //米娜桑，为什么要在这里这么干呢，明明可以在下面直接用new的，这是为了提高运作效率
        //但是这是有缺点的，就是你不能在游戏中拉伸画面，因为这个代码只运行一遍，也就是一开始就订好了宽长
        //关于窗口
        rtInfoWin = new Rect(fullWidth / 4, fullHeight / 4, fullWidth / 2, fullHeight / 2);
        stInfoWin = false;
        rtInfoWinBtn = new Rect(0, (float)(rtInfoWin.height * 0.75), rtInfoWin.width, (float)(rtInfoWin.height * 0.25));
        //设置窗口
        rtSetupWin = new Rect(fullWidth / 4, fullHeight / 4, fullWidth / 2, fullHeight / 2);
        stSetupWin = false;
        rtSetupWinBtn = new Rect(0, (float)(rtSetupWin.height * 0.75), rtSetupWin.width, (float)(rtSetupWin.height * 0.25));
        //关卡窗口
        rtLevelWin = new Rect(0, 0, fullWidth, fullHeight);
        stLevelWin = false;
        rtLevelWinBtn = new Rect(0, (float)(rtLevelWin.height*0.85), rtLevelWin.width, (float)(rtLevelWin.height * 0.15));
        LevelBtnNum = new bool[16];
	}
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        GUI.Box(rtFullscreen, PlayerPrefs.GetString("_NAME"));
        if(GUI.Button(rtBeginBtn, "航行！"))
        {
            //Application.LoadLevel("startscene");
            PlayerPrefs.DeleteAll();
        }
        //关卡窗口
        if (GUI.Button(rtLevelBtn, "星程"))
        {
            if (WindowsExist == false)
            {
                stLevelWin = true;
                WindowsExist = true;
            }
        }
        if (stLevelWin)
        {
            GUI.Window(2, rtLevelWin, doWindow,"日记");
        }
        //设置窗口
        if (GUI.Button(rtSetupBtn, "设置"))
        {
            if (WindowsExist == false)
            {
                stSetupWin = true;
                WindowsExist = true;
            }
        }
        if (stSetupWin)
        {
            GUI.Window(3, rtSetupWin, doWindow, "设置信息");
        }
        //关于窗口
        if (GUI.Button(rtInfoBtn, "关于"))
        {
            if (WindowsExist == false)
            {
                stInfoWin = true;
                WindowsExist = true;
            }
        }
        if (stInfoWin)
        {
            GUI.Window(4, rtInfoWin, doWindow, "关于信息");
        }
        
    }
    //窗口事件
    void doWindow(int winID)
    {
        if (winID == 4)
        {
            if (GUI.Button(rtInfoWinBtn, "关闭"))
            {
                stInfoWin = false;
                WindowsExist = false;
            }
        }
        if (winID == 3)
        {
            if (GUI.Button(rtSetupWinBtn, "关闭"))
            {
                stSetupWin = false;
                WindowsExist = false;
            }
        }
        if (winID == 2)
        {
            GUILayout.BeginVertical("box");
            GUILayout.Box("日记",GUILayout.Height(fullHeight/8));
            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("蓝光隧道I", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("BlueWayIscene");
            }
            if(GUILayout.Button("蓝光隧道II", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("BlueWayIIscene");
            }
            if(GUILayout.Button("蓝光隧道III", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("BlueWayIIIscene");
            }
            if(GUILayout.Button("蓝光隧道IV", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("BlueWayIVscene");
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal("box");
            if(GUILayout.Button("紫光星雨I", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("PurpleRainIscene");
            }
            if(GUILayout.Button("紫光星雨II", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("PurpleRainIIscene");
            }
            if(GUILayout.Button("紫光星雨III", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("PurpleRainIIIscene");
            }
            if(GUILayout.Button("紫光星雨IV", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("PurpleRainIVscene");
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal("box", GUILayout.Height(fullHeight / 5));
            if(GUILayout.Button("红光星河I", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("RedRainIscene");
            }
            if (GUILayout.Button("红光星河II", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("RedRainIIscene");
            }
            if(GUILayout.Button("红光星河III", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("RedRainIIIscene");
            }
            if(GUILayout.Button("红光星河IV", GUILayout.Height(fullHeight / 5)))
            {
                Application.LoadLevel("RedRainIVscene");
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            if (GUI.Button(rtLevelWinBtn,"关闭"))
            {
                stLevelWin = false;
                WindowsExist = false;
            }
        }
    }
}
