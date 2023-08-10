using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using NoOpArmy.WiseFeline.Sample;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace NoOpArmy.UtilityAI.Sample
{
    public class MainAgent : MonoBehaviour
    {
        private Brain brain;
        private BlackBoard blackBoard;

        private void Awake()
        {
            brain = GetComponent<Brain>();
            blackBoard = GetComponent<BlackBoard>();
        }
        public float energy = 100;

        void Start()
        {
            blackBoard.SetVector3("bedposition", new Vector3(-8.5f, 1.083333f, -8.5f));
            blackBoard.SetVector3("doorposition", new Vector3(8.5f, 1.083333f, -8.5f));
            blackBoard.SetVector3("workposition", new Vector3(-6.5f, 1.083333f, -8.5f));
            blackBoard.SetVector3("showerposition", new Vector3(-0.45f, 1.083333f, -8.5f));
            blackBoard.SetVector3("bathroomposition", new Vector3(-2.5f, 1.083333f, -8.5f));
            blackBoard.SetVector3("kitchenposition", new Vector3(-2f, 1.083333f, 7.7f));
            blackBoard.SetVector3("cookingposition", new Vector3(-8.5f, 1.083333f, 7.7f));
            blackBoard.SetFloat("energy", energy);
            blackBoard.SetBool("workdone", false);
            blackBoard.SetBool("food", false);
            blackBoard.SetBool("foodmaterial", false);
            blackBoard.SetBool("shower", false);
            
        }
        public virtual void OnWorkSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnWorkSuccess;
            if (action != null)
            {
                if (action.Name == "Work")
                {
                    blackBoard.SetFloat("energy", 60f);
                    blackBoard.SetBool("workdone", true);
                }
            }
        }
        public virtual void OnGoToShopSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnGoToShopSuccess;
            if (action != null)
            {
                if (action.Name == "GoToShop")
                {
                    blackBoard.SetFloat("energy", 40f);
                    blackBoard.SetBool("workdone", false);
                    blackBoard.SetBool("foodmaterial", true);
                }
            }
        }
        public virtual void OnCookSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnCookSuccess;
            if (action != null)
            {
                if (action.Name == "Cook")
                {
                    blackBoard.SetFloat("energy", 30f);
                    blackBoard.SetFloat("hunger", 50f);
                    blackBoard.SetBool("food", true);
                    blackBoard.SetBool("foodmaterial", false);
                }
            }
        }
        public virtual void OnEatFoodSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnEatFoodSuccess;
            if (action != null)
            {
                if (action.Name == "EatFood")
                {
                    blackBoard.SetFloat("energy", 20f);
                    blackBoard.SetFloat("havingpee", 100f);
                    blackBoard.SetBool("food", false);
                }
            }
        }
        public virtual void OnGoToBathroomSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnGoToBathroomSuccess;
            if (action != null)
            {
                if (action.Name == "GoToBathroom")
                {
                    blackBoard.SetFloat("energy", 10f);
                    blackBoard.SetFloat("havingpee", 0f);
                    blackBoard.SetFloat("messy", 100f);
                }
            }
        }
        public virtual void OnGoToShowerSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnGoToShowerSuccess;
            if (action != null)
            {
                if (action.Name == "GoToShower")
                {
                    blackBoard.SetFloat("messy", 0f);
                    blackBoard.SetBool("shower", true);
                }
            }
        }
        public virtual void OnSleepSuccess(ActionBase action)
        {
            brain.OnActionSucceeded += OnSleepSuccess;
            if (action != null)
            {
                if (action.Name == "Sleep")
                {
                    blackBoard.SetBool("shower", false);
                }
            }
        }
    }
}
