using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Game.ScreenWord;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class UIController : MonoBehaviour
    {

        //左上角输入框
        public InputField input;
        //中下按钮
        public Button decrypt;
        //右上收集栏显示
        public Image pointCol;

        public int point_num;
        public int point_count;

        Texture2D td = null;
        Texture2D txt_bg;

        int txt_w, txt_h;
        string my_save_path;

        Color[] my_colors;
        int _w, _h;

        bool[,] is_show;

        int step = 0;

        public GameObject go;
        GameObject[] gos = new GameObject[100];
        int gos_cur = 0;


        // Use this for initialization
        void Start()
        {
            txt_h = txt_w = 120;
            _w = txt_w - 5;
            _h = txt_h - 5;

            txt_bg = new Texture2D(txt_w, txt_h);
            Color[] tdc = new Color[txt_h * txt_w];
            for (int i = 0; i < txt_w * txt_h; i++)
            {
                tdc[i] = Color.white;
            }
            txt_bg.SetPixels(0, 0, txt_w, txt_h, tdc);
            is_show = new bool[_h, _w];

            go = Resources.Load("Prefabs/pointPixel") as GameObject;

            my_save_path = Application.persistentDataPath;
            Application.CaptureScreenshot(my_save_path + "/screen.png");
        }

        // Update is called once per frame
        void Update()
        {
            switch (step)
            {
                case 0:
                    break;
                case 1:
                    step = 4;
                    my_save_path = Application.persistentDataPath;
                    Debug.Log(my_save_path);
                    Application.CaptureScreenshot(my_save_path + "/screen.png");

                    Invoke("My_WaitForSecond", 0.4f);
                    break;
                case 2:
                    step = 4;
                    my_save_path = Application.persistentDataPath;
                    StartCoroutine(WaitLoad(my_save_path + "/screen.png"));
                    break;
                case 3:
                    step = 4;
                    Cum();
                    break;
                case 4:
                    break;
            }
        }

        private void Cum()
        {
            if (td != null)
            {
                float ft;
                ft = td.GetPixel(2, td.height - _h).r;

                my_colors = td.GetPixels(2, td.height - _h, _w, _h);
                int l = my_colors.Length;
                for (int i = 0; i < _h; i++)
                {
                    for (int j = 0; j < _w; j++)
                    {
                        if (is_show[i, j])
                        {
                            if (gos_cur < point_num)
                            {
                                gos[gos_cur] = Instantiate(go);
                                gos[gos_cur].GetComponent<Capture_ts>().toward = new Vector3(j, i, 0f);
                                gos[gos_cur].SetActive(true);
                                gos_cur++;
                            }else
                            {
                                for(int k = 0;k < gos_cur; k++)
                                {
                                    gos[k].GetComponent<Capture_ts>().toward = new Vector3(0, 0, 0);
                                    gos[k].GetComponent<Capture_ts>().isDestory = true;
                                }
                                step = 0;
                                break;
                            }
                        }
                    }
                    if (step == 0)
                        break;
                }
                step = 0;
            }
        }

        private IEnumerator WaitLoad(string fileName)
        {
            WWW wwwTexture = new WWW("file:///" + fileName);
            Debug.Log(wwwTexture.url);
            yield return wwwTexture;
            td = wwwTexture.texture;
            step = 3;
        }

        void My_WaitForSecond()
        {
            step = 2;
        }

        public void InputWord()
        {
            if (input.text != "")
            {
                input.text = input.text[0].ToString();
            }
        }

        public void Btn()
        {
            Debug.Log(step);
            if (step == 0)
            {
                step = 1;
            }
        }
    }
}

