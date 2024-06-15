using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Text;


public class VoiceControl : MonoBehaviour
{
    public List<VoiceCommand> voiceCommands;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> commandsDictionary = new Dictionary<string, Action>();
    private void OnVoiceRecognized(PhraseRecognizedEventArgs speech)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", speech.text, speech.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", speech.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", speech.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if (commandsDictionary.TryGetValue(speech.text, out Action action))
        {
            action?.Invoke();
        }
    }

    void Awake()
    {
        AssignCommands();

        keywordRecognizer = new KeywordRecognizer(commandsDictionary.Keys.ToArray(), ConfidenceLevel.Rejected);
        keywordRecognizer.OnPhraseRecognized += OnVoiceRecognized;
        keywordRecognizer.Start();
    }

    private void AssignCommands()
    {
        foreach (var command in voiceCommands)
        {
            foreach(var cmd in command.Commands)
            {
                commandsDictionary.Add(cmd, command.Execute);
            }
        }
    }

    private void OnDisable()
    {
        keywordRecognizer.OnPhraseRecognized -= OnVoiceRecognized;
        keywordRecognizer.Stop();
    }
}



