using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace EasyUI.Dialogs
{



    public class Dialog
    {
        public string Title = "Title";
        public string Message = "Message goes here.";
        public UnityAction OnClose;
    } 

    public class DialogUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;
        [SerializeField] Button closeUIButton;
        [SerializeField] Button continueUIButton;

        Dialog dialog = new Dialog();

        //Singleton pattern
        public static DialogUI Instance;

       void Awake()
        {
            Instance = this;

            //Add close event listener
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);

            //Add continue event listener
            continueUIButton.onClick.RemoveAllListeners();
            continueUIButton.onClick.AddListener(OpenWebSite);
        }

        //Set Dialog Title
        public DialogUI SetTitle ( string title )
        {
            dialog.Title = title;
            return Instance;
        }

        //Set Dialog Message
        public DialogUI SetMessage (string message)
        {
            dialog.Message = message;
            return Instance;
        }

        //Set OnClose
        public DialogUI OnClose( UnityAction action)
        {
            dialog.OnClose = action;
            return Instance;
        }


        public DialogUI OnContinue(UnityAction action)
        {
            dialog.OnClose = action;
            return Instance;
        }




        //Show dialog
        public void Show ()
        {
            titleUIText.text = dialog.Title;
            messageUIText.text = dialog.Message;

            canvas.SetActive (true);
        }

        //Hide dialog
        public void Hide()
        {
            canvas.SetActive(false);

            //Invoke OnClose Event
            if (dialog.OnClose != null)
                dialog.OnClose.Invoke();


            //Reset Dialog
            dialog = new Dialog();
        }


        public void OpenWebSite()
        {
            Application.OpenURL("https://helpusdefend.com/");
            Debug.Log("Web Browser openned on HelpUsDefend page! :-)");
        }
       
    }

}

