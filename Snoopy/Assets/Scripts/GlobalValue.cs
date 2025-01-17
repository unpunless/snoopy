using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalValue
{
    public static int[] g_WoodStock = new int[3];
    public static int[] g_Key = new int[4];
    public static int[] g_Gita = new int[2];
    public static int[] g_Tv = new int[2];
    public static int[] g_SpeechBubble = new int[3];
    public static int[] g_clock = new int[2];

    public static void ClearGame()
    {
        for (int set_WoodStock = 0; set_WoodStock < g_WoodStock.Length; set_WoodStock++)
        {
            g_WoodStock[set_WoodStock] = 0;
        }

        for (int clear_Key = 0; clear_Key < g_Key.Length; clear_Key++)
        {
            g_Key[clear_Key] = 0;
        }

        for (int clear_Gita = 0; clear_Gita < g_Gita.Length; clear_Gita++)
        {
            g_Gita[clear_Gita] = 0;
        }

        for (int clear_Tv = 0; clear_Tv < g_Tv.Length; clear_Tv++)
        {
            g_Tv[clear_Tv] = 0;
        }

        for (int set_Bubble = 0; set_Bubble < g_SpeechBubble.Length; set_Bubble++)
        {
            g_SpeechBubble[set_Bubble] = 0;
        }

        for (int ClockImg = 0; ClockImg < g_clock.Length; ClockImg++)
        {
            g_clock[ClockImg] = 0;
        }
    }
}