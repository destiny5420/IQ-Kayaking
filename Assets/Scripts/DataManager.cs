using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct DataStruct
{
    public Sprite[] m_spriteAry;
}

public class DataManager : MonoBehaviour
{
    static DataManager m_clsDataManager;
    public static DataManager GetInstance() { return m_clsDataManager; }

    // Question
    List<string> m_lisData;
    List<int> m_lisHistoryAnswer;
    int m_iGetQuestionIndex;
    [SerializeField] DataStruct[] m_aryDataImages;

    // IQ
    int iCurValueForIQ;

    void Awake()
    {
        m_clsDataManager = this;
        DontDestroyOnLoad(this);
        Create_Question();
        Init();
    }

    void Start () 
    {
        Init();
	}
	
    void Init()
    {
        m_iGetQuestionIndex = 0;
        iCurValueForIQ = 90;
    }

	void Update () 
    {
        
	}

    void Create_Question()
    {
        m_lisData = new List<string>()
        {
            "鱷魚的下半身在水下時是什麼樣子呢? (站立)(游泳)",
            "海牛除了擺動尾鰭，還會用哪種方式游泳? (放屁)(蛙式)",
            "鮪魚游泳會休息嗎? (不會)(會)",
            "北捷的文湖線不會經過哪一條線? (紫)(橘)",
            "孔子沒有寫過哪本書? (禮記)(左傳)",
            "品客的LOGO是哪一個?",
            "C_urage－勇氣 (O)(A)",
            "３ｘ５＋６ｘ２＝? (27)(45)",
            "2018極客窩遊戲黑客松是11月幾日? (10)(11)",
            "7-11的英文拼音哪的字母是小寫? (e)(n)",
            "哪個字母在鍵盤上有凸起? (H)(J)",
            "蘋果的缺口是哪一邊? (左)(右)",
            "√9 + √16 + √25 = ? (12)(14)",
        };

        m_lisHistoryAnswer = new List<int>();

        for (int i = 0; i < m_lisData.Count; i++)
            m_lisHistoryAnswer.Add(0);

        SettingHistory();
    }

    void SettingHistory()
    {
        int[] randomArray = new int[m_lisData.Count];
        System.Random rnd = new System.Random();

        for (int i = 0; i < m_lisData.Count; i++)
        {
            randomArray[i] = rnd.Next(0, m_lisData.Count);   //亂數產生，亂數產生的範圍是1~9

            for (int j = 0; j < i; j++)
            {
                while (randomArray[j] == randomArray[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                {
                    j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                    randomArray[i] = rnd.Next(0, m_lisData.Count);   //重新產生，存回陣列，亂數產生的範圍是1~9
                }
            }
        }

        for (int i = 0; i < randomArray.Length; i++)
        {
            m_lisHistoryAnswer[i] = randomArray[i];
            //Debug.Log(string.Format("HistoryAnswer[{0}]: {1}", i, m_lisHistoryAnswer[i]));
        }
        //Debug.Log(string.Format("=================== Setting complete "));
    }

    public string GetQuestion()
    {
        
        int iQuestionIndex = m_lisHistoryAnswer[m_iGetQuestionIndex];
        string sQuestionString = m_lisData[iQuestionIndex];

        GameLogic.GetInstance().SettingAnserImage(m_aryDataImages[iQuestionIndex].m_spriteAry);

        m_iGetQuestionIndex++;
        if (m_iGetQuestionIndex >= m_lisData.Count)
        {
            m_iGetQuestionIndex = 0;
            SettingHistory();
        }

        return sQuestionString;
    }

    public List<string> GetStringData()
    {
        return m_lisData;
    }

    public void IncreaseIQ(int v_value)
    {
        iCurValueForIQ += v_value;
    }

    public void DecreaseIQ(int v_value)
    {
        iCurValueForIQ -= v_value;
    }

    public int GetValueIQ()
    {
        return iCurValueForIQ;
    }
}
