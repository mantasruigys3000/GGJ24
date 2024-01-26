using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TMPro;
using System.Linq;
using System;

public class GenerateResponse : MonoBehaviour
{

    #region Variables
    public List<TMP_Text> textBoxes;
    internal List<string> selectedResponses = new();
    Random random = new Random();

    #region Responses
    internal List<string> posResponseList = new List<string> 
    {"Love you mum", 
     "Be back soon", 
     "All's well!",
     "<3",
     "Don't worry",
     "Not now please mum",
     "Networking with peers :)",
     "👍"
    };
    internal List<string> negResponseList = new List<string>
    {"Begone wench",
     "You cannot help me, hag",
     "Not this time",
     "I am sniping aliens in town.",
     "They are coming!!!",
     "THEY ATE MITTENS!",
     "I am the final bastion",
     "You might be one of them",
     "🍆",
     "akfheowsubvndsh"
    };
    #endregion Responses

    #endregion Variables

    void Start()
    {
        selectedResponses = selectResponses();
        for (int i = 0; i < selectedResponses.Count; i++)
        {
            textBoxes[i].text = selectedResponses[i];
        }
    }

    void Update()
    {
        
    }

    internal List<string> selectResponses()
    {
        Console.WriteLine(random.Next(posResponseList.Count));
        selectedResponses.Add(posResponseList[random.Next(posResponseList.Count)]);
        var negSelect1 = random.Next(negResponseList.Count);
        var negSelect2 = random.Next(negResponseList.Count);
        selectedResponses.Add(negResponseList[negSelect1]);
        while (negSelect1 == negSelect2)
        {
            negSelect2 = random.Next(negResponseList.Count);
        }
        selectedResponses.Add(negResponseList[negSelect2]);
        selectedResponses = selectedResponses.OrderBy(x => random.Next()).ToList();
        return selectedResponses;
    }
}
