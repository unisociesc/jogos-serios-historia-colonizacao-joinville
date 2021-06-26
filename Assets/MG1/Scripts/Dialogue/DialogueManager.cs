using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;
    public Text buttonText;
    public GameObject uiObject;

    private Queue<string> sentences;
    private DialogueTrigger tref;

    CompassTarget compassTarget;

    // Start is called before the first frame update
    void Start() {
        compassTarget = GetComponent<CompassTarget>();

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger reft) {
        Debug.Log("Começou o dialogo!");

        this.tref = reft;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            Time.timeScale = 1;
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        if(sentences.Count == 0) {
            buttonText.text = "Fechar";
        }
    }

    void EndDialogue() {
        Debug.Log("acabou aqui...");
        tref.DestroyActor();
        uiObject.SetActive(false);
    }
}
