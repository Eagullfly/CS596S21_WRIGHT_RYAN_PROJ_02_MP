﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlockingBehavior : MonoBehaviour
{
    public FlockController flock;

    //public Transform[] targets;

    Vector2 scrollViewVector = Vector2.zero;
    public Rect dropDownRect = new Rect(125, 50, 125, 300);
    public static string[] modes = { "Lazy Flight", "Circle a Tree", "Follow the Leader" };

    int indexNumber;
    bool show = false;

    void Start()
    {
        //flock = GameObject.FindGameObjectWithTag("FlockController").GetComponent<FlockController>();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect((dropDownRect.x - 100), dropDownRect.y, dropDownRect.width, 25), ""))
        {
            if (!show)
            {
                show = true;
            }
            else
            {
                show = false;
            }
        }
        if (show)
        {
            scrollViewVector = GUI.BeginScrollView(new Rect((dropDownRect.x - 100), (dropDownRect.y + 25), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (modes.Length * 25))));

            GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (modes.Length * 25))), "");

            for (int index = 0; index < modes.Length; index++)
            {

                if (GUI.Button(new Rect(0, (index * 25), dropDownRect.height, 25), ""))
                {
                    show = false;
                    indexNumber = index;


                }

                GUI.Label(new Rect(5, (index * 25), dropDownRect.height, 25), modes[index]);
            }
            if (indexNumber == 0)
            {
                flock.setLazy();
                //flock.target = targets[0];
                //Debug.Log("Lazy Flight");
            }

            if (indexNumber == 1)
            {
                flock.setCircle();
                //flock.target = WayPointManager.points[0];
                //Debug.Log("Circle a Tree");
            }

            if (indexNumber == 2)
            {
                flock.setFollow();
                //flock.target = targets[1];
                //Debug.Log("Follow the Leader");
            }
            GUI.EndScrollView();
        }
        else
        {
            GUI.Label(new Rect((dropDownRect.x - 95), dropDownRect.y, 300, 25), modes[indexNumber]);


        }
    }


}