using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class MessageHandler : MonoBehaviour
{
    #region Variables
    internal List<GameObject> messageList = new List<GameObject>(4);
    public GameObject panel;
    public GameObject textMessage;
    public GameObject responseMessage;

    internal GameObject messageObject;
    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //create textMessage
            var newMessage = createMessage("message");
        }   
        if (Input.GetKeyDown("tab"))
        {
            //pop
            popMessage();
        }
    }

    internal void popMessage()
    {
        Debug.Log("Message Popped");
        if (messageList.Count != 0)
        {
            Destroy(messageList[0]);
            Destroy(panel.transform.GetChild(0));
            for (int i = 0; i < 3; i++)
            {
                messageList[i] = messageList[i + 1];
            }
            messageList[3] = null;
        }
    }

    internal GameObject createMessage(string messageType)
    {
        switch (messageType)
        {
            case "message":
                {
                    var messageObject = Instantiate(textMessage, panel.transform);
                    break;
                }
            case "response":
                {
                    var messageObject = Instantiate(responseMessage, panel.transform);
                    break;
                }
        }
        for (int i = 0; i < messageList.Count; i++)
        {
            if (messageList[i] == null)
            {
                messageList[i] = messageObject;
            }
        }
        return messageObject;
    }

}
