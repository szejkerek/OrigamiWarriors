using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System;


public class VoiceControllTemplate : MonoBehaviour
{
    // Object for keyword recognition for voice control.
    private KeywordRecognizer keywordRecognizer;


    // Dictionary storing keywords and corresponding actions.
    private Dictionary<string, Action> dictionary = new Dictionary<string, Action>();

    // Event handling for voice recognition.
    private void OnVoiceRecognized(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        dictionary[speech.text].Invoke();
    }


    void Start()
    {
        // Initialize voice recognition
            dictionary.Add("left", Left);
            dictionary.Add("pravel", Right);

            // Initialize keyword recognition
            keywordRecognizer = new KeywordRecognizer(dictionary.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += OnVoiceRecognized;
            keywordRecognizer.Start();
     }


    void Update()
    {/*..*/}

    /// Functions for navigating through settings.
    private void Right()
    {
       //move right
    }
    private void Left()
    {
       //move left
    }
}



