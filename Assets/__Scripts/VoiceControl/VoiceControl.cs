using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Text;


public class VoiceControl : MonoBehaviour
{
    public bool debugPhrases = true;
    public Transform phraseParent;
    public VoicePhraseView phrasePrefab;

    public List<VoiceCommand> voiceCommands;

    private bool voiceEnabled = false;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> commandsDictionary = new Dictionary<string, Action>();
    private void OnVoiceRecognized(PhraseRecognizedEventArgs speech)
    {
      if (voiceEnabled)
      {
        if(debugPhrases) PrintPhrase(speech);

        if (commandsDictionary.TryGetValue(speech.text, out Action action))
        {
          action?.Invoke();
        }
      }
    }

  private void Update()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      voiceEnabled = true;
    }
  }

  private static void PrintPhrase(PhraseRecognizedEventArgs speech)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", speech.text, speech.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", speech.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", speech.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
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
            var phraseUI = Instantiate(phrasePrefab, phraseParent);
            phraseUI.Init(command);

            foreach(var phrase in command.VoicePhrases)
            {
                commandsDictionary.Add(phrase, command.Execute);
            }
        }
    }

    private void OnDisable()
    {
        keywordRecognizer.OnPhraseRecognized -= OnVoiceRecognized;
        keywordRecognizer.Stop();
    }
}



