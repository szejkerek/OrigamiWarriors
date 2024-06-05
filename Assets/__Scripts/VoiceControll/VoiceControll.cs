using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Text;


public class VoiceControll : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> commands = new Dictionary<string, Action>();
    private void OnVoiceRecognized(PhraseRecognizedEventArgs speech)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", speech.text, speech.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", speech.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", speech.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if (commands.TryGetValue(speech.text, out Action action))
        {
            action?.Invoke();
        }
        else
        {
            //Debug.LogWarning($"Command '{speech.text}' not found in the commands.");
        }
    }

    void Awake()
    {
        commands.Add("command", null);
        commands.Add("dupa", null);

        keywordRecognizer = new KeywordRecognizer(commands.Keys.ToArray(), ConfidenceLevel.Rejected);
        keywordRecognizer.OnPhraseRecognized += OnVoiceRecognized;
        keywordRecognizer.Start();
     }

    private void OnDisable()
    {
        keywordRecognizer.OnPhraseRecognized -= OnVoiceRecognized;
        keywordRecognizer.Stop();
    }
}



